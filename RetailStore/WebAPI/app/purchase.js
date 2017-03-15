"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const core_1 = require("@angular/core");
core_1.Injectable();
class Purchase {
    constructor(purchaseId, accessoryId, clientId, quantity, purchaseDate) {
        this.purchaseId = purchaseId;
        this.accessoryId = accessoryId;
        this.clientId = clientId;
        this.quantity = quantity;
        this.purchaseDate = purchaseDate;
    }
}
exports.Purchase = Purchase;
//# sourceMappingURL=purchase.js.map