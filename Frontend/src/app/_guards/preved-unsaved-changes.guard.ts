import { Injectable } from '@angular/core';
import { CanDeactivate } from '@angular/router';
import { UserEditComponent } from '../components/user/user-edit/user-edit.component';

@Injectable()
export class PreventUnsevedChanges implements CanDeactivate<UserEditComponent> {
    canDeactivate(component: UserEditComponent) {
        if (component.editForm.dirty) {
            return confirm('Na pewno chcesz wyjść? Niezapisane zmiany zostaną utracone.');
        }
        return true;
    }
}
