import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IconDefinition } from '@fortawesome/fontawesome-svg-core';
import { faUserCircle } from '@fortawesome/free-solid-svg-icons';
import { Localization } from '../shared/models/localization.model';
import { ProfileService } from './profile.service';
import { User } from './user.model';

@Component({
    selector: 'profile',
    templateUrl: './profile.component.html',
    styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
    private faUserCircle: IconDefinition = faUserCircle;
    private user: User;
    private local: Localization;

    constructor(private router: Router, private profileService: ProfileService) { }

    ngOnInit(): void {
        this.user = this.profileService.getInforamationAboutUser();
        this.local = this.profileService.getLocalization();
        this.profileService.castInitEvent(this.local.aboutMe);
    }
}
