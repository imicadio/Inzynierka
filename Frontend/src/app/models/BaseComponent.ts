import * as moment from 'moment';

export abstract class BaseComponent { 

    public getToday(): string{
        var today = new Date();
        var nextDay = new Date(today.getFullYear(), today.getMonth(), today.getDate());
        return nextDay.toDateString();
    }

    public getNextWeek(): string{
        var today = new Date();
        var nextWeek = new Date(today.getFullYear(), today.getMonth(), today.getDate() + 7);
        return nextWeek.toISOString();
    }
}