import { Injectable } from '@angular/core';
import { VisitorService } from './visitor.service';
import { UserInformations } from './user-informations';
import { ApplicationService } from '../pages/application/application.service';
import { BeginnerLessonsService } from '../pages/lessons/beginner-list/shared/beginner-lessons.service';

@Injectable({
  providedIn: 'root'
})
export class LocalServiceService {

  constructor(
    private visitorService: VisitorService,
    private applicationService: ApplicationService,
    private beginnerLessonsService: BeginnerLessonsService) { }

  startApp() {   
    this.setLocalDefaults();
  }

  initStorage(lang:string, userInfo: UserInformations){
    
    this.applicationService.getKeyboardWithLanguageCode(navigator.language).subscribe(_ =>{
      if(_){
          localStorage.clear();
          localStorage.setItem('bkId', _.id);
          localStorage.setItem('version', 'v3');
          localStorage.setItem('kb', JSON.stringify(_.data));
          localStorage.setItem('keyCodes', JSON.stringify(_.codeKeys));
          localStorage.setItem('beginnersCodes', JSON.stringify(_.keycodesBeginners));
          localStorage.setItem('userInfo', JSON.stringify(userInfo));
          this.beginnerLessonsService.buildLessonsBeginners(_.keycodesBeginners);
      }
      
    });
  }

  setLocalDefaults() {
    
    if(localStorage.getItem('version') != 'v3'){
      
      this.visitorService.getIp().subscribe(x => {
        if (x.ip) {
          this.visitorService.getLocationWithIp(x.ip).subscribe((_: any) => {
            const userInfo: UserInformations = {
              country: _.country,
              region: _.region,
              city: _.city,
              language: navigator.language,
              ip: x.ip
            };
            if (navigator.language == 'fr') {
              if(_.country == 'Canada' && _.region == 'QC'){
                this.initStorage('fr-CA', userInfo);
              }
              if(_.country == 'France'){
                this.initStorage('fr', userInfo);
              }
            } else {
              this.initStorage(navigator.language, userInfo);
            }
          })
        }
      })
    } else {
      this.beginnerLessonsService.buildLessonsBeginners(JSON.parse(localStorage.getItem('beginnersCodes')));
    }
  }

  setKeyboardDefault(userInformations: UserInformations) {
    if(userInformations.country == 'Canada' && userInformations.region == 'QC' && userInformations.language.includes('fr')) {
      
    }
  }

  containsLocal(key: string): boolean {
    return !!localStorage.getItem(key);
  }
}
