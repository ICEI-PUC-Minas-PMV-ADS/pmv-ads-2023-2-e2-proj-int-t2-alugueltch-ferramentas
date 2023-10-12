const debounce = (callback, time) => {
    let timeoutId = null

    return (...args) => {
        window.clearTimeout(timeoutId)

        timeoutId = setTimeout(() => {
            callback.apply(null, args)
        }, time)
    }
}

const formatPhoneNumber = (phoneNumber) => {
    const formattedPhoneNumber = phoneNumber.replace(/(\d{2}|\d{1})(\d{4})(\d{4})/, '($1) $2-$3');

    return formattedPhoneNumber;
}

export { debounce, formatPhoneNumber }