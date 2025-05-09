VAR cassette_count = 5
CONST cassette_goal = 5
VAR quest_ingredients_var = false
VAR quest_cassettes_var = true
VAR quest_fox = false

// ->collect_cassette
-> start
=== start ===
-> flower_intro

=== flower_intro ===
"Флауі: Привіт! Схоже, ти новенький тут..."
"Флауі: Тут або ВБИВАЮТЬ, або ВИЖИВАЮТЬ! ХАХАХА!"
"Раптово він атакує тебе!"

-> flower_fight
=== flower_fight ===
"Починається бій..."
// Тут можна вставити геймплей
"Ти дивом ухилився. Але Флауі зникає..."
-> meet_toriel

=== meet_toriel ===
"Торіель: Бідолаха! Ходімо до мене додому — я подбаю про тебе."
"Вона веде тебе до теплого дому з печивом."
-> quest_ingredients

=== quest_ingredients ===
"Торіель: Мені не вистачає одного інгредієнта для пирога. Сходиш у магазин?"
+ "Так, звісно!" -> go_to_shop
+ "Ні, я зайнятий." -> quest_ingredients_refuse

= quest_ingredients_refuse
"Торіель: Ну добре, але пирога не буде :("
-> END

= go_to_shop
"Ти виходиш із дому та йдеш до маленького магазину в лісі..."
// гравець проходить зону і знаходить інгредієнт
"Інгредієнт знайдено!"
~ quest_ingredients_var = true
-> return_to_toriel_after_shop

= return_to_toriel_after_shop
"Торіель: Чудово! А тепер... Ще одна справа."
-> quest_cassettes

=== quest_cassettes ===
"Торіель: Я загубила 5 касет. Вони важливі для магічного ритуалу."
~ quest_cassettes_var = true
-> END

=== collect_cassette ===

{quest_cassettes_var:
    ~ cassette_count += 1

    {cassette_count == 1:
        "Перша касета знайдена. Виглядає давньою."
    }

    {cassette_count == 2:
        "Ще одна. Вона трохи тріснута."
    }

    {cassette_count == 3:
        "Третя касета. Здається, щось на ній записано."
    }

    {cassette_count == 4:
        "Четверта касета. Лишилась остання!"
    }

    {cassette_count == cassette_goal:
        "Ура! Ти знайшов усі касети! Повернись до Торіель."
    }
- else:
    "Ти ще не отримав це завдання."
}

-> END



=== return_with_cassettes ===
{cassette_count == cassette_goal:
    "Торіель: Ти справжній герой. Ось ключ від комори. Там живуть лисиці."
    ~ quest_fox = true
    -> fox_scene
- else:
    "Торіель: Ти ще не зібрав усі касети."
    -> END
}

=== fox_scene ===
"Ти відкриваєш двері комори."
"Всередині — кілька голодних лисиць. Вони підходять до тебе обережно..."
"Одна з них заговорила: Лис: Ми чекали тебе."
-> ending

=== ending ===
"Епічна катсцена запускається..."
"Ти завершив усі три мініквести! Що ж буде далі?.."
-> END
