import { trigger, state, animate, transition, style } from '@angular/animations';

export const slideInOutAnimation = trigger('slideInOutAnimation', [
    // state('*', style({
    //   transform: 'translateX(0)'
    // })),
  
    // route 'enter' transition
    // transition(':enter', [
    //   style({
    //     transform: '*'
    //   }),
    //   animate('.3s ease-in-out', style({
    //     transform: 'translateX(-100%)'
    //   }))
    // ]),

    state('slideLeft', style({
      transform: 'translateX(0%)'
    })),

    state('slideLeftLeft', style({
      transform: 'translateX(0%)'
    })),

    state('slideRight', style({
      transform: 'translateX(0%)'
    })),

    state('slideRightRight', style({
      transform: 'translateX(0%)'
    })),

    transition('* => slideLeft', [
      animate('.3s ease-in-out', style({
        transform: 'translateX(100%)'
      }))
    ]),

    transition('slideLeft <=> slideLeftLeft', [
      animate('.3s ease-in-out', style({
        transform: 'translateX(100%)'
      }))
    ]),

    transition('slideRight <=> slideRightRight', [
      animate('.3s ease-in-out', style({
        transform: 'translateX(-100%)'
      }))
    ]),

    transition('* => slideRight', [
      animate('.3s ease-in-out', style({
        transform: 'translateX(-100%)'
      }))
    ]),


    // transition('slideLeft => slideLeft', [
    //   animate('.3s ease-in-out', style({
    //     transform: 'translateX(100%)'
    //   }))
    // ]),

    // transition('slideLeft => slideLeft', [
    //   animate('.3s ease-in-out', style({
    //     transform: 'translateX(0%)'
    //   }))
    // ])

    // route 'leave' transition
    // transition(':leave', [
    //   animate('.3s ease-in-out', style({
    //     transform: 'translateX(100%)'
    //   }))
    // ])
  ]);