import { Injector } from "@angular/core";
import { TranslateService } from "@ngx-translate/core";
import { Router, ActivatedRoute } from "@angular/router";

export class LanguageComponenet {
    lang: string;

    constructor( 
        public translate: TranslateService,
        protected route: ActivatedRoute,
        protected router: Router) {
    }

    init() {
        this.lang = this.translate.currentLang;
        this.route.params.subscribe(value => {
            if (value['lang'] === undefined) {
                const langBrowser = navigator.language.substring(0, 2);
                this.router.navigate(['/' + langBrowser]);
            }
            this.translate.use(value['lang'])
        });
    }
}