import { CURRENT_DATE, DAYS_OF_WEEK, MONTH_NAMES } from "./utils/constants.js";

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
    isInvalidDate: (date) => date.isBefore(CURRENT_DATE),
  });

  $(rangeDatePicker).on(
    "apply.daterangepicker",
    function (_, { startDate, endDate }) {
      calculateTotal();
    }
  );
};

$.ready.then(() => {
  buildRangeDateFieldConfiguration();

  $("#report-generate").on("click", (e) => {
    console.log(e);
  });
});
