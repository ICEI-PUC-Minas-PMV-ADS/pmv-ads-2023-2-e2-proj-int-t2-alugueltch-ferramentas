const debounce = (callback, time) => {
    let timeoutId = null

    return (...args) => {
        window.clearTimeout(timeoutId)

        timeoutId = setTimeout(() => {
            callback.apply(null, args)
        }, time)
    }
}

export { debounce }