import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Observable, of, throwError } from 'rxjs';
import { catchError, map, tap } from "rxjs/operators";
import { Item } from "./Item";

@Injectable({
  providedIn: 'root',
})
export class ScraperService{
  scraperApi = 'https://localhost/5001/';

  constructor(private http: HttpClient) { }

  getAllItems(): Observable<Item[]> {
    return this.http.get<Item[]>(this.scraperApi +'allItems')
    .pipe(
      tap(_ => console.log('fetched heroes')),
      catchError(this.handleError<Item[]>('allItems', []))
    );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      console.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}
