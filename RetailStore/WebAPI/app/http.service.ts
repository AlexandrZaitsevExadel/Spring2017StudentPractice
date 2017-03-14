import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions} from '@angular/http';

@Injectable()
export class HttpService {

    constructor(private http: Http) { }

    Read() {
        return this.http.get('api/purchases');
    }
    Add(model, clientName){
        let headers = new Headers({
            'Content-Type':
            'application/json; charset=utf-8'
        });
        let options = new RequestOptions({ headers: headers });
        //delete model["purchaseId"];
        let body = JSON.stringify(model) + clientName;
        //body.concat(clientName);
        return this.http.post('api/purchases', body, options).subscribe();
    }
    Update(model) {
        let headers = new Headers({
            'Content-Type':
            'application/json; charset=utf-8'
        });
        let options = new RequestOptions({ headers: headers });
        let body = JSON.stringify(model);
        return this.http.put('api/purchases', body, options);
    }
    Delete(id: number) {
        return this.http.delete('api/purchases?id=' + id);
    }
}