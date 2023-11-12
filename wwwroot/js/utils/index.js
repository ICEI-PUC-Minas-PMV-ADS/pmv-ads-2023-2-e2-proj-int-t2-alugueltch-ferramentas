const debounce = (callback, time) => {
  let timeoutId = null;

  return (...args) => {
    window.clearTimeout(timeoutId);

    timeoutId = setTimeout(() => {
      callback.apply(null, args);
    }, time);
  };
};

const formatPhoneNumber = (phoneNumber) => {
  const formattedPhoneNumber = phoneNumber.replace(
    /(\d{2}|\d{1})(\d{4})(\d{4})/,
    "($1) $2-$3"
  );

  return formattedPhoneNumber;
};

const formatNumberToCurrency = (number) => {
  return Intl.NumberFormat("pt-BR", {
    style: "currency",
    currency: "BRL",
  }).format(number);
};

const calculatePeriodInDays = (startDate, endDate) => {
  return endDate.diff(startDate, "days");
};

const reloadWindow = () => {
  setTimeout(() => {
    location.reload();
  }, 1000);
};

export {
  debounce,
  reloadWindow,
  formatPhoneNumber,
  formatNumberToCurrency,
  calculatePeriodInDays,
};
