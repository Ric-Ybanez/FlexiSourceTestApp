import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { environment } from '../../environments/environment';
import { StringMatchRequest } from '../models/string-match.request';
import { StringMatchResponse } from '../models/string-match.response';

@Component({
  selector: 'app-string-match',
  templateUrl: './string-match.component.html'
})

export class StringMatchComponent {

  request = {} as StringMatchRequest;
  response = {} as StringMatchResponse;

  constructor(
    public http: HttpClient,
    @Inject('BASE_URL') public baseUrl: string
  ) { }

  submitClick() {
   this.stringMatch(this.request);  
  }

  stringMatch(model: StringMatchRequest) {
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };
    const endpoint = `${this.baseUrl}api/Text`;
    console.log(endpoint);
    return this.http.post<StringMatchResponse>(endpoint, JSON.stringify(model), httpOptions)
      .subscribe((response) => {
        this.response = response;
      });
  }

}

