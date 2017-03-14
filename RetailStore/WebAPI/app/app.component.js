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
    }
    refresh() {
        this.httpService.Read().subscribe((resp) => this.purchases = resp.json());
    }
    ngOnInit() {
        this.refresh();
    }
    onUpdate(elem) {
        this.httpService.Update(elem).subscribe(data => { this.refresh(); });
    }
    onDelete(id) {
        this.httpService.Delete(id).subscribe(data => { this.refresh(); });
        this.refresh();
    }
};
AppComponent = __decorate([
    core_1.Component({
        selector: 'my-app',
        template: ` <p>If this the only thing you see then something went wrong</p>
                <div class='row'>
                  <div class="panel panel-default">                
                    <div class='panel-heading'>Purchases List</div>
                    <div class='panel-body'>
                    <table class='table table-condensed'>
                      <thead>
                        <th>PurchaseId</th>
                        <th>AccessoryId</th>
                        <th>ClientId</th>
                        <th>Quantity</th>
                        <th>PurchaseDate</th>
                      </thead>
                      <tbody>
                        <tr *ngFor="let purchase of purchases">
                          <td>{{purchase?.purchaseId}}</td>
                          <td>{{purchase?.accessoryId}}</td>
                          <td>{{purchase?.clientId}}</td>
                          <td><input type="text" 
                            [(ngModel)]="purchase.quantity"  name="quantity" class="form-control" /> </td>
                          <td>{{purchase?.purchaseDate}}</td>
                          <td> <input type="button" 
                            value="BuyExtra" class="btn btn-default" 
                            (click)="onUpdate(purchase)"/> 
                            <input type="button" value="Redo" 
                            class="btn btn-danger"  
                            (click)="onDelete(purchase.purchaseId)"/></td>
                        </tr>
                      </tbody>
                    </table>
                    </div>
                  </div>
                </div>`,
        providers: [http_service_1.HttpService]
    }),
    __metadata("design:paramtypes", [http_service_1.HttpService])
], AppComponent);
exports.AppComponent = AppComponent;
//# sourceMappingURL=app.component.js.map