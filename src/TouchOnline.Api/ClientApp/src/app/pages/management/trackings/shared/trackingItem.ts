export class TrackingItem {
    visitedPages: string;
    listsCount: number;
    appCount: number;
    resultCount: number;
    startDate: Date;
    endDate: Date;
    userId: string;
    ip: string;

    constructor(json: any) {
        console.log('parse json', )
        this.startDate = json.startDate;
        this.endDate = json.endDate;
        this.userId = json.userId;
        this.ip = json.ip;
        this.buildResultCount(json.visitedPages);
    }

    buildResultCount(visitedPages) {
        let listRes: any[] = [];
        const list: any[] = visitedPages.split('/').filter(_ => _ !== '');
        list.forEach((_: Page[]) => _.forEach(p => console.log(p)))
        

        this.resultCount = list.filter(_ => _[0].name === 'result')
        .map(_ => _.count)
        .reduce((a, b) => a + b, 0);

        this.listsCount = list.filter(_ => 
            _[0].name === 'list-beginners' || _[0].name === 'list-basics' ||
            _[0].name === 'list-intermediates' || _[0].name === 'list-advanceds' ||
            _[0].name === 'list-myText'
            )
        .map(_ => _.count)
        .reduce((a, b) => a + b, 0);

        this.appCount = list.filter(_ => _[0].name === 'app')
        .map(_ => _.count)
        .reduce((a, b) => a + b, 0);

        this.appCount = list.filter(_ => _[0].name === 'app')
        .map(_ => _.count)
        .reduce((a, b) => a + b, 0);
    }
}

export class Page {
    name: string;
    count: number;
}