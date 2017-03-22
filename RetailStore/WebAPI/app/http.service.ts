import { Injectable } from "@angular/core";
import { Http, Headers, RequestOptions} from "@angular/http";

@Injectable()
export class HttpService {

    constructor(private http: Http) { }

    readPurchases() {
        return this.http.get("api/purchases");
    }
    readAccessories() {
        return this.http.get("api/accessories");
    }
    add(model){
        const headers = new Headers({
            'Content-Type':
                "application/json; charset=utf-8"
        });
        const options = new RequestOptions({ headers: headers });
        const body = JSON.stringify(model);
        console.log(body);
        return this.http.post("api/purchases", body, options);
    }
    update(model) {
        const headers = new Headers({
            'Content-Type':
                "application/json; charset=utf-8"
        });
        const options = new RequestOptions({ headers: headers });
        const body = JSON.stringify(model);
        return this.http.put("api/purchases", body, options);
    }
    delete(id: number) {
        return this.http.delete(`api/purchases?id=${id}`);
    }
}