import {
  CURRENT_DATE,
  DAYS_OF_WEEK,
  ERROR_TOAST_CONFIG,
  MONTH_NAMES,
  SUCCESS_TOAST_CONFIG,
  VALIDATION_ERROR_TOAST_CONFIG,
} from "./utils/constants.js";
import { formatNumberToCurrency, reloadWindow } from "./utils/index.js";

let rangeDatePicker;
let instances = {};

const calculatePeriodInDays = (startDate, endDate) => {
  return endDate.diff(startDate, "days");
};

const calculateTotalValue = (selectedTools, periodInDays) =>
  selectedTools.reduce((acc, { valorCompra, valorDiaria }) => {
    return acc + valorCompra + valorDiaria * periodInDays;
  }, 0);

const calculateTotal = () => {
  const { tools } = instances;
  const { startDate, endDate } = rangeDatePicker.data("daterangepicker");
  const selectedTools = tools.getSelection();

  if (!selectedTools.length || !startDate || !endDate) {
    $("#total-input").val(0.0);
  } else {
    const periodInDays = calculatePeriodInDays(startDate, endDate);
    const totalValue = calculateTotalValue(selectedTools, periodInDays);

    $("#total-input").val(totalValue.toFixed(2));

    return totalValue;
  }

  return "0.0";
};

const buildRangeDateFieldConfiguration = () => {
  rangeDatePicker = $("#date-range").daterangepicker({
    startDate: CURRENT_DATE,
    autoApply: true,
    timePicker: true,
    timePickerSeconds: true,
    locale: {
      format: "DD/MM/YYYY",
      fromLabel: "De",
      toLabel: "Até",
      applyLabel: "Aplicar",
      cancelLabel: "Cancelar",
      daysOfWeek: DAYS_OF_WEEK,
      monthNames: MONTH_NAMES,
    },
    parentEl: "data-retirada",
    customRangeLabel: "Intervalo Personalizado",
    autoUpdateInput: true,
    isInvalidDate: (date) => date.isBefore(CURRENT_DATE),
  });

  $(rangeDatePicker).on(
    "apply.daterangepicker",
    function (_, { startDate, endDate }) {
      calculateTotal();
    }
  );
};

const omitCpf = (cpf) => {
  let maskedCpf = "";

  if (cpf) {
    maskedCpf = cpf.replace(
      /(\d{3})(\d{3})(\d{3})(\d{2})/,
      (_, part_1, part_2, part_3, part_4) => `${part_1}.***-${part_4}`
    );
  }

  return maskedCpf;
};

const clearClientAdditionalFields = () => {
  const fields = [
    "#complemento",
    "#logradouro",
    "#numero",
    "#cidade",
    "#bairro",
    "#estado",
    "#pais",
    "#cep",
    "#email",
    "#telefone",
    "#data-nascimento",
  ];

  fields.forEach((field) => {
    $(field).text("");
  });
};

const fillClientAdditionalFields = (clientData) => {
  const { email, telefone, endereco, dataNascimento } = clientData;

  $("#complemento").text(endereco.complemento);
  $("#logradouro").text(endereco.logradouro);
  $("#numero").text(endereco.numero);
  $("#cidade").text(endereco.cidade);
  $("#bairro").text(endereco.bairro);
  $("#estado").text(endereco.estado);
  $("#pais").text(endereco.pais);
  $("#cep").text(endereco.cep);

  $("#email").text(email);
  $("#telefone").text(telefone);
  $("#data-nascimento").text(moment(dataNascimento).format("DD/MM/YYYY"));
};

const formatClientOptions = ({ nome, cpf }) => {
  const template = `
      <div style="padding: 5px; overflow:hidden;">
          <div style="float: left; margin-left: 5px">
              <div style="font-weight: bold; color: #333; font-size: 14px; line-height: 16px">
                  ${nome} - ${omitCpf(cpf)}
              </div>
          </div>
      </div><div style="clear:both;"></div>
      `;

  return template;
};

const formatToolsOptions = ({ descricao, valorCompra, valorDiaria, marca }) => {
  const template = `
    <div style="padding: 5px; overflow:hidden;">
        <div style="float: left; margin-left: 5px; ">
            <div style="font-weight: bold; color: #333; font-size: 14px; line-height: 16px">
              ${descricao} - [${marca}]
            </div>
            <div style="color: #999; font-size: 12px">
                Valor fixo: ${formatNumberToCurrency(valorCompra)} 
                | Diária: ${formatNumberToCurrency(valorDiaria)}
            </div>
        </div>
    </div><div style="clear:both;"></div>
    `;

  return template;
};

const onChangeClientValue = (_, magicSuggest) => {
  const [selectedOption] = magicSuggest.getSelection();
  const [optionValue] = magicSuggest.getValue();

  if (optionValue) {
    fillClientAdditionalFields(selectedOption);
  } else {
    clearClientAdditionalFields();
  }
};

const onChangeToolsValue = (_, magicSuggest) => {
  const optionsValues = magicSuggest.getValue();

  calculateTotal();
};

const configureMagicSuggestField = (
  selector,
  options,
  onChangeCallback,
  keyName
) => {
  const instance = $(selector).magicSuggest({
    method: "GET",
    allowFreeEntries: false,
    ...options,
  });

  $(instance).on("selectionchange", onChangeCallback);

  instances[keyName] = instance;
};

const updateRendHtmlTemplate = () => {
  const { startDate, endDate } = getFormData();
  const [{ nome, email, endereco, telefone }] =
    instances["client"].getSelection();

  $("#customer-name").text(nome);
  $("#customer-phone").text(telefone);
  $("#customer-email").text(email);
  $("#customer-address").text(
    `${endereco.logradouro}, ${endereco.numero}, ${endereco.bairro} - ${endereco.cidade} ${endereco.estado}`
  );

  const tools = instances["tools"].getSelection();
  let total = 0;

  const toolsContainer = $("#tools");

  tools.forEach((tool) => {
    const toolElement = $("<div>");
    toolElement.html(`
          <h6>${tool.descricao}</h6>
          <small>Valor Aluguel: R$${tool.valorCompra.toFixed(2)}</small> | 
          <small>Valor Diária: R$${tool.valorDiaria.toFixed(2)}</small>
          <hr />
      `);
    toolsContainer.append(toolElement);

    total += tool.valorCompra;
  });

  const datePattern = "DD/MM/YYYY";

  $("#rent").text(moment(startDate).format(datePattern));
  $("#devolution").text(moment(endDate).format(datePattern));

  $("#total").text(`TOTAL: R$ ${total.toFixed(2)}`);

  reloadWindow();
};

const generatePdf = async (element) => {
  updateRendHtmlTemplate();

  const stringyfiedPdf = await html2pdf()
    .from(element)
    .outputPdf("datauristring");

  const template = `<embed width='100%' height='100%' src="${stringyfiedPdf}"/>`;
  const windowInstance = window.open();

  windowInstance.document.open();
  windowInstance.document.write(template);
  windowInstance.document.close();
};

const buildToolsFieldConfiguration = () => {
  configureMagicSuggestField(
    "#tools-select",
    {
      required: true,
      valueField: "codigo",
      displayField: "descricao",
      queryParam: "descricao",
      data: "/api/ferramentumsapi",
      placeholder: "Selecionar ferramentas",
      renderer: formatToolsOptions,
      selectionRenderer: ({ descricao, marca }) => {
        return `<div>${descricao} - ${marca}</div>`;
      },
    },
    onChangeToolsValue,
    "tools"
  );
};

const buildClientFieldConfiguration = () => {
  configureMagicSuggestField(
    "#client-select",
    {
      required: true,
      valueField: "cpf",
      queryParam: "nome",
      displayField: "nome",
      data: "/api/clientesapi",
      placeholder: "Selecionar cliente",
      maxSelection: 1,
      renderer: formatClientOptions,
      selectionRenderer: ({ nome, cpf }) => {
        return `<div>${nome} - ${omitCpf(cpf)}</div>`;
      },
      maxSelectionRenderer: () => "Permitido selecionar apenas 1 cliente",
    },
    onChangeClientValue,
    "client"
  );
};

const createRental = async (clientCpf, toolsIds, startDate, endDate) => {
  const requestPayload = {
    clienteCpf: clientCpf,
    ferramenta: toolsIds.map((toolId) => ({
      codigo: toolId,
      quantidade: 1,
    })),
    dataOrcamento: startDate,
    dataValidade: endDate,
  };

  const response = await fetch("/api/orcamentosapi", {
    method: "POST",
    body: JSON.stringify(requestPayload),
    headers: {
      "Content-Type": "application/json",
    },
  });

  if (response.ok) {
    Toastify(SUCCESS_TOAST_CONFIG).showToast();
    reloadWindow();
  } else {
    Toastify(ERROR_TOAST_CONFIG).showToast();
  }
};

const initOnGenerateRentalListener = () => {
  $("#gerar-orcamento").on("click", (_) => {
    const element = document.getElementById("pdf-content");

    if (checkIfFormIsValid()) {
      generatePdf(element);
    }
  });
};

const getFormData = () => {
  const datePattern = "YYYY-MM-DDTHH:mm:ss";
  const datePickerInstance = rangeDatePicker.data("daterangepicker");

  const [clientCpf] = instances["client"].getValue();
  const toolsValues = instances["tools"].getValue();
  const startDate = datePickerInstance.startDate.format(datePattern);
  const endDate = datePickerInstance.endDate.format(datePattern);

  return {
    clientCpf,
    toolsValues,
    startDate,
    endDate,
  };
};

const checkIfFormIsValid = () => {
  const { clientCpf, toolsValues } = getFormData();
  const isFormValid = clientCpf && toolsValues && toolsValues.length;

  if (!isFormValid) {
    Toastify(VALIDATION_ERROR_TOAST_CONFIG).showToast();

    return;
  }

  return true;
};

const initFormSubmitListener = () => {
  $("form").submit((event) => {
    event.preventDefault();

    if (checkIfFormIsValid()) {
      const { clientCpf, toolsValues, startDate, endDate } = getFormData();

      createRental(clientCpf, toolsValues, startDate, endDate);
    }
  });
};

$.ready.then(() => {
  buildToolsFieldConfiguration();
  buildClientFieldConfiguration();
  buildRangeDateFieldConfiguration();

  initOnGenerateRentalListener();
  initFormSubmitListener();
});
