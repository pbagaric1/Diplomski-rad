import { trigger, state, animate, transition, style } from '@angular/animations';

export const slideAnimation = trigger('slideAnimation',
    [
        transition(
            "void => prev", // ---> Entering --->
            [
                // In order to maintain a zIndex of 2 throughout the ENTIRE
                // animation (but not after the animation), we have to define it
                // in both the initial and target styles. Unfortunately, this
                // means that we ALSO have to define target values for the rest
                // of the styles, which we wouldn't normally have to.
                style({
                    left: -100,
                    opacity: 0.0,
                    zIndex: 2
                }),
                animate(
                    "200ms ease-in-out",
                    style({
                        left: 0,
                        opacity: 1.0,
                        zIndex: 2
                    })
                )
            ]
        ),
        transition(
            "prev => void", // ---> Leaving --->
            [
                animate(
                    "200ms ease-in-out",
                    style({
                        left: 100,
                        opacity: 0.0
                    })
                )
            ]
        ),
        transition(
            "void => next", // <--- Entering <---
            [
                // In order to maintain a zIndex of 2 throughout the ENTIRE
                // animation (but not after the animation), we have to define it
                // in both the initial and target styles. Unfortunately, this
                // means that we ALSO have to define target values for the rest
                // of the styles, which we wouldn't normally have to.
                style({
                    left: 100,
                    opacity: 0.0,
                    zIndex: 2
                }),
                animate(
                    "200ms ease-in-out",
                    style({
                        left: 0,
                        opacity: 1.0,
                        zIndex: 2
                    })
                )
            ]
        ),
        transition(
            "next => void", // <--- Leaving <---
            [
                animate(
                    "200ms ease-in-out",
                    style({
                        left: -100,
                        opacity: 0.0
                    })
                )
            ]
        )
    ]
)