const MONTH_NAMES = [
  "Janeiro",
  "Fevereiro",
  "Março",
  "Abril",
  "Maio",
  "Junho",
  "Julho",
  "Agosto",
  "Setembro",
  "Outubro",
  "Novembro",
  "Dezembro",
];

const DAYS_OF_WEEK = ["Dom", "Seg", "Ter", "Qua", "Qui", "Sex", "Sáb"];

const CURRENT_DATE = Date.now();

const SUCCESS_TOAST_CONFIG = {
  text: "Aluguel realizado com sucesso!",
  duration: 3000,
  destination: "https://github.com/apvarun/toastify-js",
  style: {
    background: "#008000",
  },
};

const ERROR_TOAST_CONFIG = {
  text: "Houve um erro ao realizar o aluguel!",
  duration: 3000,
  style: {
    background: "#ff0000",
  },
};

const VALIDATION_ERROR_TOAST_CONFIG = {
  text: "Os campos cliente e ferramenta são obrigatórios",
  duration: 3000,
  style: {
    background: "#ff0000",
  },
};

export {
  MONTH_NAMES,
  DAYS_OF_WEEK,
  CURRENT_DATE,
  ERROR_TOAST_CONFIG,
  SUCCESS_TOAST_CONFIG,
  VALIDATION_ERROR_TOAST_CONFIG,
};
