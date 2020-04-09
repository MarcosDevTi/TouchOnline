import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-seo-list',
  templateUrl: './seo-list.component.html',
  styleUrls: ['./seo-list.component.css']
})
export class SeoListComponent implements OnInit {
lang: string;
  constructor(public translate: TranslateService) { }

  ngOnInit() {
    this.lang = this.translate.currentLang;
  }

}
