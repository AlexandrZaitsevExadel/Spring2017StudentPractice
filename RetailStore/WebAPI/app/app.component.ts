import { Component, OnInit } from '@angular/core';
import { Response } from '@angular/http';
import { HttpService } from './http.service';
import { Purchase } from './purchase';
import { Subscription } from 'rxjs/Subscription';

@Component({
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
    providers: [HttpService]
})
export class AppComponent implements OnInit {
    purchases: Purchase[]=[];

    refresh() {
        this.httpService.Read().subscribe((resp: Response) => this.purchases = resp.json());
    }
    constructor(private httpService: HttpService) { }
    ngOnInit() {
        this.refresh();
    }
    onUpdate(elem) {
        this.httpService.Update(elem).subscribe(data => { this.refresh();});
        
    }
    onDelete(id: number) {
        this.httpService.Delete(id).subscribe(data => { this.refresh(); });
        this.refresh();
    }
}