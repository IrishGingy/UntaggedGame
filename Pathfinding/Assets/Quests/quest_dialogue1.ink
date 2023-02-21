# speaker Lenny
Have you noticed the fallen boards in the fence?

 # speaker Sully
 * Yeah, it should be fine...right?
    There are wolves out there man, no it's not gonna be fine! We need somebody to talk to the shepherd, we're kind of living in squalor here.
    -> squalor
 # speaker Sully
 * Fallen boards? I haven't noticed.
    You haven't noticed? Get your eyes checked man, because we are living in squalor here.
    -> squalor
 
= squalor
 * Squalor?
    Beyond the fallen boards, we're running out of grass to eat, it's gonna start getting cold out here soon, and don't even get me started on the giant hole in the middle of the pasture...we miss you Bill.
    ** [Bill?] Wait, I thought Bill just went missing?
        No man, I was with him when he fell in. I saw it with my own eyes. It needs to be fixed before more of us fall in.
        *** I'll talk to him.
            -> talk_to_the_shepherd
        *** I'll ask around.
            Alright, well just in case you decide to do it: Talk to Mikey by the big rock. He'll guide you through the process. Oh and don't tell him that I was the one who told you. We're not on great terms him and I.
            -> DONE
    ** [I'll talk to him.] Ok, well I'll talk to him.
        -> talk_to_the_shepherd

= talk_to_the_shepherd
You will? Man, that means so much to me, thanks! Let me know what he says. You know how to reach him?
    * No
        Talk to Mikey by the big rock. He'll guide you through the process.
    * I can probably figure it out, thanks
# speaker Lenny
- Ok cool. Oh hey don't tell him that it was me that referred you. We're kind of not on the best terms right now.
    -> END
