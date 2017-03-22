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
    templateUrl: `app/app.component.html`,
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