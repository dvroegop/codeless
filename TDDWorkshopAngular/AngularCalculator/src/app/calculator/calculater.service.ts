import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Observable, map, mergeMap, of, retry, throwError } from "rxjs";
@Injectable({
    providedIn: 'root'
})
export class CalculaterInputService {

    private noOfRetriesOnFailure = 3;

    constructor(private http: HttpClient) { }

    getInput() {
        return this.http.get<string | Error>('')
            .pipe(
                mergeMap(val => {
                    if (val === undefined) return of(Error('API Failed'));
                    // Otherwise
                    return of(val);
                }),
                retry(this.noOfRetriesOnFailure),
                map(val => val)
            );
    }

}