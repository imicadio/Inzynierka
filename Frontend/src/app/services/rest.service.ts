import { Injectable } from "@angular/core";

@Injectable()
export class RestService {

}

export function queryStringify(obj: any) {
    var objToString = (prefix: string, object: any): string => {
        const str = [];
        for (const p in object) {
            if (object.hasOwnProperty(p)) {
                let value = prefix + encodeURIComponent(p) + '=' + encodeURIComponent(object[p]);
                str.push(value);
            }
        }

        return str.join('&');
    }
    const str = [];
    for (const p in obj) {
        if (obj.hasOwnProperty(p)) {
            if (obj[p] instanceof Array) {
                for (const arrayItem in obj[p]) {
                    let value = encodeURIComponent(p) + '=' + encodeURIComponent(obj[p][arrayItem]);

                    str.push(value);
                }
            }
            else if (obj[p] instanceof Object) {
                let value = objToString(p + ".", obj[p]);

                str.push(value);
            }
            else {
                let value = encodeURIComponent(p) + '=' + encodeURIComponent(obj[p]);

                str.push(value);
            }
        }
    }
    return str.join('&');
}
