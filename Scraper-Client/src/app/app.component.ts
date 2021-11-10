import { Component, OnInit } from '@angular/core';
import { Item } from './Item';
import { ScraperService } from './scraper.Service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  constructor(public scraperService: ScraperService) {}
  ngOnInit(){

  }
  title = 'Scraper-Client';
  itemList: Item[] =[]


}
