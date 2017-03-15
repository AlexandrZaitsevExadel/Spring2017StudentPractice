import { Injectable } from '@angular/core';

Injectable()
export class Purchase {
    purchaseId: number;
    accessoryId: number;
    clientId: number;
    quantity: number;
    purchaseDate: Date;
    constructor(purchaseId: number,
        accessoryId: number,
        clientId: number,
        quantity: number,
        purchaseDate: Date) {
        this.purchaseId = purchaseId;
        this.accessoryId = accessoryId;
        this.clientId = clientId;
        this.quantity = quantity;
        this.purchaseDate = purchaseDate;
    }
}