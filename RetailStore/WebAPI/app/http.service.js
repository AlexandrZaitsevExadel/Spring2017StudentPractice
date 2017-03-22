"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
const core_1 = require("@angular/core");
const http_1 = require("@angular/http");
let HttpService = class HttpService {
    constructor(http) {
        this.http = http;
    }
    readPurchases() {
        return this.http.get("api/purchases");
    }
    readAccessories() {
        return this.http.get("api/accessories");
    }
    add(model) {
        const headers = new http_1.Headers({
            'Content-Type': "application/json; charset=utf-8"
        });
        const options = new http_1.RequestOptions({ headers: headers });
        const body = JSON.stringify(model);
        console.log(body);
        return this.http.post("api/purchases", body, options);
    }
    update(model) {
        const headers = new http_1.Headers({
            'Content-Type': "application/json; charset=utf-8"
        });
        const options = new http_1.RequestOptions({ headers: headers });
        const body = JSON.stringify(model);
        return this.http.put("api/purchases", body, options);
    }
    delete(id) {
        return this.http.delete(`api/purchases?id=${id}`);
    }
};
HttpService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_1.Http])
], HttpService);
exports.HttpService = HttpService;
//# sourceMappingURL=http.service.js.map