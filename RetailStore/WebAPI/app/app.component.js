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
const http_service_1 = require("./http.service");
let AppComponent = class AppComponent {
    constructor(httpService) {
        this.httpService = httpService;
        this.purchases = [];
        this.accessories = [];
        this.addPurchase = { accessoryId: 0, clientName: "", quantity: 0 };
    }
    refresh() {
        this.httpService.readPurchases().subscribe((resp) => this.purchases = resp.json());
    }
    ngOnInit() {
        this.refresh();
        this.httpService.readAccessories().subscribe((resp) => this.accessories = resp.json());
    }
    onAdd(addPurchase) {
        this.httpService.add(addPurchase).subscribe(data => {
            console.log("Success! " + data);
            this.refresh();
        }, error => { console.log(JSON.stringify(addPurchase) + " Error happened : " + error); }, function () {
            console.log("the subscription is completed");
            this.refresh();
        });
    }
    onUpdate(model) {
        this.httpService.update(model).subscribe(data => {
            console.log(JSON.stringify(model));
            this.refresh();
        });
    }
    onDelete(id) {
        this.httpService.delete(id).subscribe(data => { this.refresh(); });
        this.refresh();
    }
    onSelect() {
        console.log("addPurchase.accessoryId = " + this.addPurchase.accessoryId);
    }
};
AppComponent = __decorate([
    core_1.Component({
        selector: "my-app",
        templateUrl: `app/app.component.html`,
        providers: [http_service_1.HttpService]
    }),
    __metadata("design:paramtypes", [http_service_1.HttpService])
], AppComponent);
exports.AppComponent = AppComponent;
//# sourceMappingURL=app.component.js.map