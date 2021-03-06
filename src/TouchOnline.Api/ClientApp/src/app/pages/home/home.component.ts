import { Component, OnInit } from '@angular/core';
import { TrackingService } from 'src/app/pages/tracking/shared/tracking.service';
import { TranslateService } from '@ngx-translate/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  lang: string;
  constructor(
    private trackingService: TrackingService,
    public translate: TranslateService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit() {
    const langLocal = localStorage.getItem('lang');
    if (langLocal) {
      this.translate.use(langLocal)
      this.router.navigate(['/' + langLocal]);
    }
    else {
      this.route.params.subscribe(value => {
        console.log(value['lang']);
        if (value['lang'] === undefined) {
         // const langBrowser = navigator.language.substring(0, 2);
          this.router.navigate(['/']);
          this.translate.use('en');
        } else {
          this.translate.use(value['lang']);
        }
        
      });
    }

    this.trackingService.setvisitedPages('home');
  }

}
