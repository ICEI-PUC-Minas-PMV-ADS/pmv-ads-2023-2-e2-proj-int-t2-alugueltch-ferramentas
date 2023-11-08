import { CURRENT_DATE, DAYS_OF_WEEK, MONTH_NAMES } from "./utils/constants.js";
import { formatNumberToCurrency } from "./utils/index.js";


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
  }
};

const configureDatePickerField = () => {
  rangeDatePicker = $("#date-range").daterangepicker({
    startDate: CURRENT_DATE,
    autoApply: true,
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
      const pattern = "YYYY-MM-DD";

      $("#hidden-initial-date-input").val(startDate.format(pattern));
      $("#hidden-final-date-input").val(endDate.format(pattern));

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
  const hiddenToolsInput = $("#hidden-tools-input");

  hiddenToolsInput.val(
    optionsValues.length ? JSON.stringify(optionsValues) : "[]"
  );

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


const generatePdf = async (element) => {
  
  const stringyfiedPdf = await html2pdf()
    .from(element)
    .outputPdf('datauristring')
 
  const template = `<embed width='100%' height='100%' src="${stringyfiedPdf}"/>`
  const windowInstance = window.open();

  windowInstance.document.open();
  windowInstance.document.write(template);
  windowInstance.document.close();
}

$.ready.then(() => {
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

  $('#gerar-orcamento').on('click', (_) => {
    const element = document.getElementById('pdf-content')

    generatePdf(element)
  })
  

 
  configureDatePickerField();
});
