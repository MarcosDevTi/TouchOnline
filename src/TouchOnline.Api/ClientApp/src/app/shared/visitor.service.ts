import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class VisitorService {
ipAddress;

constructor(private http: HttpClient) { }

getLocation() {
  this.http.get('http://api.ipify.org/?format=json').subscribe((res: any) => {
    console.log(res);
    this.http.get(
      `http://ip-api.com/json/${res.ip}?fields=status,message,continent,continentCode,country,countryCode,region,` +
      'regionName,city,district,zip,lat,lon,timezone,isp,org,as,asname,reverse,mobile,proxy,hosting,query').subscribe((ress: any) => {
    });
  });
}

getLocationWithIp(ip): Observable<Location> {
  return this.http.get<Location>(
    `http://ip-api.com/json/${ip}?fields=status,message,continent,continentCode,country,countryCode,region,` +
    'regionName,city,district,zip,lat,lon,timezone,isp,org,as,asname,reverse,mobile,proxy,hosting,query');
}

getIp(): Observable<any> {
   return this.http.get('http://api.ipify.org/?format=json');
}

}
