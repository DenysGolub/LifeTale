VAR cassette_count = 0
CONST cassette_goal = 5
VAR quest_ingredients_var = false
VAR quest_cassettes_var = false

VAR quest_ingredients_ended = false
VAR quest_casettes_ended = false
VAR quest_fox = false
VAR met_toriel = false
VAR got_apple = false
VAR has_met_foxes = false
VAR is_end_game = false
VAR quest_count = 0
EXTERNAL StartFight()
EXTERNAL SpawnTorielAndDisableFlowey()
EXTERNAL SpawnTorielAtHome()
EXTERNAL SpawnApple()
EXTERNAL SpawnCasettes()
EXTERNAL StartFox()
EXTERNAL PlayFoxLaugh()
EXTERNAL SpawnEndPortal()

-> start

=== start ===
-> flower_intro

=== flower_intro ===
"Flowey: Hi there! Looks like you're new here..."
"Flowey: In this world, it's KILL or BE KILLED! HAHAHA!"
~StartFight()
-> flower_fight

=== flower_fight ===
Say goodbye to your life!
Hm?
That goat is coming again.
You're lucky this time.
~SpawnTorielAndDisableFlowey()
-> meet_toriel

=== meet_toriel ===
"Toriel: Poor thing! Come with me to my home — I'll take care of you."
My house is ahead. Go forward.
~met_toriel = true
~SpawnTorielAtHome() 

-> END

=== quest_ingredients ===
"Toriel: I need an apple for my pie. Could you please go to the tree and pick one?"
"You agree and head towards the tree."
~ quest_ingredients_var = true
~ SpawnApple()

-> done_quest_ingredients

=== done_quest_ingredients ===
-> END

=== return_to_toriel_after_tree ===
~ quest_ingredients_ended = true
"Toriel: Wonderful! Now... there's one more task."
~ quest_count += 1
-> quest_cassettes

=== quest_cassettes ===
"Toriel: I've lost 5 cassettes. They have really cool music recorded, and I can't finish without them :(("
"Toriel: Please find them while I finish baking the pie."
~ quest_cassettes_var = true
~ SpawnCasettes()

-> END

=== collect_cassette ===
{quest_cassettes_var:
    ~ cassette_count += 1

    {cassette_count == 1:
        "You found the first cassette. Looks pretty old."
    }

    {cassette_count == 2:
        "Another one. This one has a little crack."
    }

    {cassette_count == 3:
        "The third cassette. Seems like something's recorded on it."
    }

    {cassette_count == 4:
        "The fourth cassette. Only one left!"
    }

    {cassette_count == cassette_goal:
        "Hooray! You've found all the cassettes! Return to Toriel."
    }
- else:
    "You haven't received this quest yet."
}

-> END

=== return_with_cassettes ===
{cassette_count == cassette_goal:
    {quest_casettes_ended == false:
        ~ quest_count += 1
    }
    "Toriel: You're a real hero. Here’s the key to the storeroom. There are foxes living there."
    ~ quest_casettes_ended = true
    ~ StartFox()
    ~ quest_fox = true
    "You've received the key and can now visit the foxes."

- else:
    "Toriel: You haven't collected all the cassettes yet."
}

-> END

=== fox_scene ===
{has_met_foxes == false:
    ~ quest_count += 1
    ~ quest_fox = true
}

~ has_met_foxes = true
"You look at the fox."
"The fox looks back at you."
"You stand there in shock."
"One of them, wearing large glasses, speaks up: 
Fox Programmer: Oh, this is definitely not the player we were waiting for. I thought we were expecting the project leader!"
"The other one, drawing something on the board, adds: 
Fox Artist: Mmm... No, this must be a test character. 
Interesting... but still a bit rough."
~ PlayFoxLaugh()
"The Programmer and Artist glance at each other and laugh."
"Fox Programmer: Well, you're probably a bit broken because of the bugs in our level. That's why we're stuck here!"
"Fox Artist: We're breaking the fourth wall and all that! So... what your thoughts about this game?"
"Fox Programmer: I've spawned a portal for you, so you can quit whenever you want"
~ SpawnEndPortal()
~ is_end_game = true

-> END

=== fox_scene_one_action === 
~ PlayFoxLaugh()
Fox Programmer: No more dialogues, one-time action :D
-> END
