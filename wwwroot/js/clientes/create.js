/**
 * Buscar CEP pelo input
 */

import { debounce } from "../utils.js"


const checkIfValidCep = (cep) => {
    const isValidCep = /^\d{5}\d{3}$/.test(cep)

    return cep && isValidCep
}

const getAddressByCep = async (cep) => {
    if(!checkIfValidCep(cep)) {
        return ''
    }
    
    const url = `https://viacep.com.br/ws/${cep}/json/`    

    try {
        const response = await fetch(url)
        const data = await response.json()

        return data
        
    } catch (_) {
        return ''
    }
} 

const fillAddressFields = (address) => {

    const {
        complemento,
        localidade,
        logradouro,
        bairro,
        uf
    } = address

    const inputLogradouro = document.getElementById('input-logradouro')
    inputLogradouro.textContent = logradouro

    console.log(inputLogradouro)
    console.log(logradouro)

    // const inputComplemento = document.getElementById('input-complemento')
    // inputComplemento.textContent = complemento

    // const inputBairro = document.getElementById('input-bairro')
    // inputBairro.textContent = bairro

    // const inputCidade = document.getElementById('input-cidade')
    // inputCidade.textContent = localidade

    // const inputEstado = document.getElementById('input-estado')
    // inputEstado.textContent = uf
}


const handleCepFieldChange = debounce(async (event) => {
    const eventTarget = event.target
    const inputValue = eventTarget.value
    const response = await getAddressByCep(inputValue)

    if(!response) {
        return
    }
    
    fillAddressFields(response)
}, 300)

/**
 * Fim buscar CEP pelo input
 */


/**
 * Preencher países
 */

const getCountries = async () => {
    const response = await fetch("/assets/utils/countries.json")
    const countries = await response.json()

    return  countries
}

const createSelectOptions = (data) => {
    return data.map(({name, code}) => {
        return `<option value="${code}">${name}</option>`
    })
}

const fillCountyField = async  () => {
    const { countries } = await getCountries()
    
    const selectPaises = document.getElementById('select-paises')
    const options = createSelectOptions(countries)
    
    selectPaises.innerHTML = options
}

/**
 * Fim preencher países
 */

window.onload = () => {
    const cepField =  document.getElementById('input-cep');
    cepField.addEventListener("input", handleCepFieldChange);

    fillCountyField()
}