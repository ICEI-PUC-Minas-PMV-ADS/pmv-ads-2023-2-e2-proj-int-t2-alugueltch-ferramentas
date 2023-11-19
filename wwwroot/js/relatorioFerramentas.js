import { CURRENT_DATE, DAYS_OF_WEEK, MONTH_NAMES } from "./utils/constants.js";
import { formatNumberToCurrency } from "./utils/index.js";

let rangeDatePicker;

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
    isInvalidDate: (date) => date.isAfter(moment(CURRENT_DATE).add(1, "d")),
  });
};

const updateRentHtmlTemplate = (data) => {
  const tableBody = $("#report-table__body");

  let template = "";

  data.forEach((tool) => {
    template += `
        <tr>
            <td scope="row">${tool.id}</td>
            <td>${tool.codigo}</td>
            <td>${tool.descricao}</td>
            <td>${tool.funcionarioCadastroFuncional}</td>
            <td>${formatNumberToCurrency(tool.valorCompra)}</td>
            <td>${formatNumberToCurrency(tool.valorDiaria)}</td>
        </tr>;
        `;
  });

  tableBody.html(template);
};

const createRentReportPdf = async (element, data) => {
  updateRentHtmlTemplate(data);

  const opt = {
    html2canvas: {
      scale: 2,
    },
    jsPDF: {
      unit: "in",
      format: "a4",
      orientation: "landscape",
    },
  };

  const stringyfiedPdf = await html2pdf()
    .set(opt)
    .from(element)
    .outputPdf("datauristring");

  const template = `<embed width='100%' height='100%' src="${stringyfiedPdf}"/>`;
  const windowInstance = window.open();

  windowInstance.document.open();
  windowInstance.document.write(template);
  windowInstance.document.close();
};

const createReport = async (startDate, endDate) => {
  const response = await fetch(`/api/FerramentumsApi`);

  const parsedResponse = await response.json();
  const pdfTemplateElement = document.getElementById("pdf-content");

  createRentReportPdf(pdfTemplateElement, parsedResponse);
};

$.ready.then(() => {
  buildRangeDateFieldConfiguration();

  $("#report-generate").on("click", (e) => {
    const datePattern = "YYYY-MM-DD HH:mm:ss";
    const datePickerInstance = rangeDatePicker.data("daterangepicker");

    const startDate = datePickerInstance.startDate.format(datePattern);
    const endDate = datePickerInstance.endDate.format(datePattern);

    createReport(startDate, endDate);
  });
});
