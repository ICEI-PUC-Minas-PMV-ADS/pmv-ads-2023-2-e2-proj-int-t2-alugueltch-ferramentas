const debounce = (callback, time) => {
    let timeoutId = null

    return (...args) => {
        window.clearTimeout(timeoutId)

        timeoutId = setTimeout(() => {
            callback.apply(null, args)
        }, time)
    }
}

const getEmployees = async () => {
    const response = await fetch('/Funcionarios/GetAllEmployees')
    const jsonResponse = await response.json()

    return jsonResponse;
}

const filterEmployeesByName = async (searchTherm) => {
    const employees = (await getEmployees()).$values;

    return employees.filter(({ Nome }) => {
        const employeeName = Nome.toLowerCase();
        const lowerCaseSearchTherm = searchTherm.toLowerCase()

        return employeeName.includes(lowerCaseSearchTherm)
    })
}

const handleInputChanges = debounce(async (event) => {
    const inputElement = event.target
    const searchTherm = inputElement.value
    const filteredEmployees = await filterEmployeesByName(searchTherm)

    console.log(filteredEmployees)
}, 300)

window.onload = () => {
    const searchInput = document.querySelector('#search')
    searchInput.addEventListener('input', handleInputChanges);
}