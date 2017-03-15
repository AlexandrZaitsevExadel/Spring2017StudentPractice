import { Component, OnInit } from '@angular/core';
import { Response } from '@angular/http';
import { HttpService } from './http.service';
import { Purchase } from './purchase';
import { Subscription } from 'rxjs/Subscription';
import { NgForm } from '@angular/forms';



@Component({
    selector: 'my-app',
    template: ` <div class='row'>
                    <form>
                    <div>
                        <label for="pAccessoryId">AccessoryId *</label>
                        <input type="number" class="form-control"
                            [(ngModel)]="addPurchase.accessoryId" name="pAccessoryId" required>
                    </div>
                    <div>
                        <label for="clientName">ClientName *</label>
                        <input type="text" class="form-control"
                            [(ngModel)]="clientName" name="clientName" required>
                    </div>
                    <div>
                        <label for="pQuantity">Quantity *</label>
                        <input type="number" class="form-control"
                            [(ngModel)]="addPurchase.quantity" name="pQuantity" required>
                    </div>
                    <div>
                        <button type="button" (click)="onAdd(addPurchase, clientName)"
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
    addPurchase: Purchase = new Purchase(0,0,0,0,new Date());
    clientName: string;
    refresh() {
        this.httpService.Read().subscribe((resp: Response) => this.purchases = resp.json());
    }
    constructor(private httpService: HttpService) { }
    ngOnInit() {
        this.refresh();
    }
    onAdd(addPurchase:Purchase, clientName:string) {
        this.httpService.Add(addPurchase, clientName).subscribe(
            data => { console.log("Success! " + data) },
            error => { console.log(JSON.stringify(addPurchase) + " Error happened : " + error) },
            function () { console.log("the subscription is completed") }
);
    }
    onUpdate(elem) {
        this.httpService.Update(elem).subscribe(data => {
            console.log(JSON.stringify(elem));
            this.refresh();
        });
        
    }
    onDelete(id: number) {
        this.httpService.Delete(id).subscribe(data => { this.refresh(); });
        this.refresh();
    }
}