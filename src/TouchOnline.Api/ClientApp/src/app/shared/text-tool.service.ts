import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
  })
export class TextToolService {

    wordWrap(str, maxWidth) {
        const newLineStr = '\n';
        let res = '';
        while (str.length > maxWidth) {
            let found = false;
            // Inserts new line at first whitespace of the line
            for (let i = maxWidth - 1; i >= 0; i-- ) {
                if (this.testWhite(str.charAt(i))) {
                    res = res + [str.slice(0, i), newLineStr].join('');
                    str = str.slice(i + 1);
                    found = true;
                    break;
                }
            }
            // Inserts new line at maxWidth position, the word is too long to wrap
            if (!found) {
                res += [str.slice(0, maxWidth), newLineStr].join('');
                str = str.slice(maxWidth);
            }
        }

        return res + str;
    }

    testWhite(x) {
        const white = new RegExp(/^\s$/);
        return white.test(x.charAt(0));
    }
}
