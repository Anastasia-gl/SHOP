import { makeAutoObservable } from "mobx";

export default class DeviceStore {
    constructor() {
        this._types = []
        this._device = []
        this._basket = {}
        this._productBasket = []
        this._itemBasket = []
        this._history = []
        this._selectedArray = []
        this._page = 1
        this._totalCount = 0
        this._selectedType = {}
        this._price = {}
        this._filter = {}
        this._isActive = true
        makeAutoObservable(this)
    }
 
    setActive(active){
        this._isActive = active
    }

    setPrice (price) {
        this._price = price
    }

    setSelectedArray (array) {
        this._selectedArray = array
    }

    setPage(page) {
        this._page = page
    }
    setTotalCount(count) {
        this._totalCount = count
    }

    setProductBasket(productBasket) {
        this._productBasket = productBasket;
    }

    setHistory(history) {
        this._history = history;
    }

    setItemBasket(item) {
        this._itemBasket = item;
    }

    setBasket(basket) {
        this._basket = basket;
    }

    setSelectedType(type) {
        this._selectedType = type;
    }

    setTypes(types) {
        this._types = types;
    }

    setDevices(devices) {
        this._device = devices;
    }

    setFilter(type) {
        this._filter = type;
    }
    
    get totalCount() {
        return this._totalCount
    }

    get price() {
        return this._price
    }

    get active() {
        return this._isActive
    }

    get page() {
        return this._page
    }

    get array() {
        return this._selectedArray
    }

    get productBasket() {
        return this._productBasket
    }

    get itemBasket() {
        return this._itemBasket
    }

    get basket() {
        return this._basket
    }

    get history() {
        return this._history
    }

    get selectedType() {
        return this._selectedType
    }

    get types() {
        return this._types;
    }

    get devices() {
        return this._device;
    }

    get filter() {
        return this._filter;
    }
}