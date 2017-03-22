import { Injectable } from "@angular/core";

@Injectable()
export class Purchase {
    purchaseId: number;
    accessoryId: number;
    clientId: number;
    quantity: number;
    purchaseDate: Date;
    
}