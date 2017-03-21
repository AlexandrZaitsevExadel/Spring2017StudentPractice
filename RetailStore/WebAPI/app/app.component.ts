import { Input, Component, OnInit } from '@angular/core';
import { Response } from '@angular/http';
import { HttpService } from './http.service';
import { Purchase } from './purchase';
import { Accessory } from './accessory';
import { StockPurchase } from './stockPurchase';
import { Subscription } from 'rxjs/Subscription';
import { NgForm } from '@angular/forms';



@Component({
    selector: 'my-app',
    template: ` <div class='row'>
                    <form>
                     <select class="form-control" [(ngModel)]="addPurchase.accessoryId" name="addId" (ngModelChange)="onSelect()">
                        <option *ngFor="let accessory of accessories" [ngValue]="accessory.accessoryId">{{accessory.accessoryName}}</option>
                     </select>
                     <div>
                        <label for="clientName">ClientName *</label>
                        <input type="text" class="form-control"
                            [(ngModel)]="addPurchase.clientName" name="clientName" required>
                    </div>
                    <div>
                        <label for="pQuantity">Quantity *</label>
                        <input type="number" class="form-control"
                            [(ngModel)]="addPurchase.quantity" name="addQuantity" required>
                    </div>
                    <div>
                        <button type="button" (click)="onAdd(addPurchase)"
                            class="btn btn-primary">Add
                        </button>
                    </div>
                    </form>
                </div>
                <p></p>
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
    providers: [HttpService]
})
export class AppComponent implements OnInit {
    purchases: Purchase[] = [];
    accessories: Accessory[] = [];
    addPurchase: StockPurchase = { accessoryId: 0, clientName:"", quantity:0};

    refresh() {
        this.httpService.readPurchases().subscribe((resp: Response) => this.purchases = resp.json());
    }

    constructor(private httpService: HttpService) {}

    ngOnInit() {
        this.refresh();
        this.httpService.readAccessories().subscribe((resp: Response) => this.accessories = resp.json());
    }

    onAdd(addPurchase: StockPurchase) {
        this.httpService.add(addPurchase).subscribe(
            data => {
                console.log("Success! " + data);
                this.refresh();
            },
            error => { console.log(JSON.stringify(addPurchase) + " Error happened : " + error) },
            function () {
                console.log("the subscription is completed");
                this.refresh();
            }
);
    }

    onUpdate(model) {
        this.httpService.update(model).subscribe(data => {
            console.log(JSON.stringify(model));
            this.refresh();
        });
        
    }

    onDelete(id: number) {
        this.httpService.delete(id).subscribe(data => { this.refresh(); });
        this.refresh();
    }

    onSelect()
    {
        console.log("addPurchase.accessoryId = " + this.addPurchase.accessoryId);
    }
}