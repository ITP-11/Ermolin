i=0
while test $i -ne 5
do
clear
echo 'Меню'
echo '1.Информация'
echo '2.Значение функции'
echo '3.Проверить существует ли папка в указанном месте и если да переименовать её'
echo '4.Скопировать файлы из данного каталога в папку tmp/Имя пользователя, с добавив расширение .bak'
echo '5.Выход'
echo 'Выберите пункт меню'
read i
if test $i -eq 1
    then echo 'Автор'
    echo 'Даниил Ермолин'
    echo 'группа ИТП-11'
elif test $i -eq 2
    then
    echo 'Введите № компьютера'
    read nk
    echo 'Введите № по журналу'
    read nv
    echo 'Введите Ваш возраст'
    read v
    echo 'Значение функции x=(№Компьютера + №По журналу)*Возраст равно'
    x=`expr $nk \* $v + $nv \* $v`
    echo x=$x
elif test $i -eq 3
    then
    echo 'Введите адрес папки'
    read fold
    if [ -d $fold ]
    then
    echo "Такая папка существует"
    echo 'Введите новое название папки'
    read name
    $(mv $fold $name)
    echo 'папка успешно переименована'
    else echo 'Такой папки не существует'
    fi
elif test $i -eq 4
    then
    echo 'Введите адрес папки'
    read fold
    if [ -d $fold ]
    then
    m=0
    cd $fold
    for l in *
    do
    echo "$l"
    cp $l /home/vadim/tmp/vadim
    m=`expr $m + 1 `
    done
    cd /home/vadim/tmp/vadim
    m=0
    for l in *
    do
    rename -f 's/.txt/.bak/'
    m=`expr $m + 1 `
    done
    else echo 'Такой папки не существует'
    fi
elif test $i -eq 5
    then echo 'Завершение работы'
fi
read key
done





 