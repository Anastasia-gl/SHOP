import { $host } from "./index"

export const fetchTypes = async () => {
    const { data } = await $host.get('/Type/get-types')
    return data
}

export const fetchOneDevice = async (id) => {
    const { data } = await $host.get('/Product/get-by-id/' + id)
    return data
}

export const fetchSortedDevice = async (page, limit) => {
    const { data } = await $host.get('/Product/sort-by-price/' + page + '/' + limit)
    return data
}

export const fetchCharacterisric = async (id) => {
    const { data } = await $host.get('/Characteristic/get-characteristic/' + id)
    return data
}

export const fetchFilterDevice = async (name) => {
    const { data } = await $host.get('/Type/get-type-name/' + name)
    console.log(data)
    return data
}

export const fetchDevices = async (page, limit) => {
    const { data } = await $host.get('/Product/get-list-product/' + page + '/' + limit)
    return data
}

export const fetchCountType = async (name) => {
    const { data } = await $host.get('/Type/get-count-type/' + name)
    return data
}

export const fetchBasket = async (id) => {
    const { data } = await $host.get('/Basket/get-basket-by-user/' + id)
    return data
}

export const fetchItemFromBasket = async (basketId) => {
    const { data } = await $host.get('/ProductBasket/get-items-from-basket/' + basketId);
    return data
}

export const fetchCountProduct = async () => {
    const { data } = await $host.get('/Product/count-list');
    return data
}

export const fetchListProductBasket = async (basketId) => {
    const { data } = await $host.get('/ProductBasket/get-list-from-basket/' + basketId);
    return data
}

export const fetchHistory = async (basketId) => {
    const { data } = await $host.get('/History/get-basket-history/' + basketId);
    return data
}

export const createHistory = async (basketId, historyDto) => {
    const data = await fetch('http://localhost:7213/History/add-from-basket-to-history/' + basketId, {
      method: "POST",
      headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
      },
      credentials: 'include',
      body: JSON.stringify(historyDto)
    })
  
    return data
  }

export const createBasket = async (productId, basketId) => {
    const { data } = await $host.post('/ProductBasket/add-product-to-basket/' + productId + '/' + basketId)
    return data
}

export const deleteBasket = async (productId, basketId) => {
    const { data } = await $host.delete('/ProductBasket/delete-item-from-basket/' + productId + '/' + basketId)
    return data
}