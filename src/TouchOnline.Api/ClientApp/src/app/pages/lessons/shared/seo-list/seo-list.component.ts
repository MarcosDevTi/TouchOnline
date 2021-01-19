import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { AuthService } from 'src/app/pages/auth/auth.service';

@Component({
  selector: 'app-seo-list',
  templateUrl: './seo-list.component.html',
  styleUrls: ['./seo-list.component.css']
})
export class SeoListComponent implements OnInit {
lang: string;
showPub: boolean;
isAdmin: boolean;
  constructor(public translate: TranslateService, public authService: AuthService) { }

  ngOnInit() {
    this.lang = this.translate.currentLang;
    this.setPub();
    this.isAdminRefresh();
  }
  
  // ngAfterViewInit() {
  //   (window['adsbygoogle'] = window['adsbygoogle'] || []).push({
  //                   overlays: {bottom: true}
  //               });
  // }

  isAdminRefresh() {
    this.authService.isAdmin(localStorage.getItem('userId')).subscribe(_ => {
      this.isAdmin = _;
    });
  }


  setPub() {
    const storedPub = localStorage.getItem('pub-list-left');
    if(storedPub){
      const num = Number.parseInt(storedPub);
      if(num < 10){
        localStorage.setItem('pub-list-left', (num +1).toString());
        this.showPub = false;
      } else {
        localStorage.setItem('pub-list-left', '1')
        this.showPub = true
      }
    } else {
      localStorage.setItem('pub-list-left', '1')
      this.showPub = true
    }
  }

}
