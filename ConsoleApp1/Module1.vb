Imports System.Linq.Expressions
Imports System.IO
Imports System.ComponentModel.Design
Imports System.Net
Imports System.Net.Security
Imports System.Runtime.Remoting.Services


Module Module1
    Dim sSelect, mealSelect, loopSelect As Integer
    Dim total As Single
    Dim tax As Single = 0.02
    Dim taxTotal As Single
    Dim pLoop, vInput, programLoop As Boolean
    Dim orderinfo(4, 3), orderID As String
    Dim pLoopinput As String
    Dim loopCount As Integer = 0
    Dim name, sname, bselect, mselect, tipChoice, StudentCheck, studentCheckInvalidInput As String
    Dim shopping_data() As String = File.ReadAllLines("orders.txt")
    Dim programEnter As String
    Dim programEnterInput As Boolean = False
    Dim orderCustomizer As Integer
    Dim orderCustomeizerInvalid As Boolean = False
    
    Sub studentDiscuont()
        Console.Clear()
        studentCheckInvalidInput = False
        Do
            Console.WriteLine("Are you a student(Y/N)")
            StudentCheck = UCase(Console.ReadLine())
            If StudentCheck = "Y" Then

                Console.WriteLine("Please enter your student ID number")
                Console.ReadLine()
                orderinfo(loopCount, 0) = FormatNumber(orderinfo(loopCount, 0) * 0.9, 2)
                Console.WriteLine("You are eligible for a student discount, Your new total is $" & orderinfo(loopCount, 0))
                Exit Sub

            ElseIf StudentCheck = "N" Then
                Exit Sub
            Else
                Console.WriteLine("Invalid Input, Please try again")
                studentCheckInvalidInput = True
            End If
        Loop Until studentCheckInvalidInput = False
    End Sub

    Sub orderView()
        Console.WriteLine("Press <ENTER> to display orders")
        Console.ReadLine()
        For k = 0 To UBound(shopping_data)
            Console.WriteLine((shopping_data(k)))
        Next
        Console.WriteLine("Press <ENTER> to exit program")
        Console.ReadLine()
        End
    End Sub

    
  
    Sub mealCustomizer(ByRef total)


        If mealSelect = 1 Then
            Console.WriteLine("You have selected the Basic Meal for $" & total)
            Console.WriteLine("Item          Quantity")
            Console.WriteLine("----------------------")
            Console.WriteLine("Cheese Burger        1")
            Console.WriteLine("Regular Fries        1")
            Console.WriteLine("Soda Can             1")

        ElseIf mealSelect = 2 Then
            Console.WriteLine("You have selected the Premium Meal for $" & total)
            Console.WriteLine("Item                 Quantity")
            Console.WriteLine("-----------------------------")
            Console.WriteLine("Double Cheese Burger        1")
            Console.WriteLine("Regular Fries               1")
            Console.WriteLine("Large Soda Can              1")

        ElseIf mealSelect = 3 Then
            Console.WriteLine("You have selected the Luxury Meal for $" & total)
            Console.WriteLine("Item                 Quantity")
            Console.WriteLine("-----------------------------")
            Console.WriteLine("Double Cheese Burger        1")
            Console.WriteLine("Large Fries                 2")
            Console.WriteLine("Large Soda Can              1")


        End If
        
        dim mealCustomizeDec as string 'meal customizer decision 
        dim mealCustomizeDecInput as boolean = false ' meal customize decision input loop trigger


        Console.WriteLine()
        Console.WriteLine("Would you like to customize your meal")
        Console.WriteLine("-------------------------------------")
        Console.WriteLine("Choice                       InputKey")
        Console.WriteLine("-------------------------------------")
        Console.WriteLine("YES                                 1")
        Console.WriteLine("NO                                  2")
        

        ' finish off meal customizer
        
        
        do 
            mealCustomizeDec = console.readline
        if mealCustomizeDec = "1" Then
            Console.Clear()
            
            Console.WriteLine("                               Meal Customizer                               ")
            Console.WriteLine("-----------------------------------------------------------------------------")
            If mealSelect = 1 Then
                Console.WriteLine("               You have selected the Basic Meal for $" & total)
                Console.WriteLine("               Item          Quantity")
                Console.WriteLine("               ----------------------")
                Console.WriteLine("               Cheese Burger        1")
                Console.WriteLine("               Regular Fries        1")
                Console.WriteLine("               Soda Can             1")

            ElseIf mealSelect = 2 Then
                Console.WriteLine("              You have selected the Premium Meal for $" & total) 
                Console.WriteLine("              Item                 Quantity")
                Console.WriteLine("              -----------------------------")
                Console.WriteLine("              Double Cheese Burger        1")
                Console.WriteLine("              Regular Fries               2")
                Console.WriteLine("              Large Soda Can              1")

            ElseIf mealSelect = 3 Then
                Console.WriteLine("              You have selected the Luxury Meal for $" & total)
                Console.WriteLine("              Item                 Quantity")
                Console.WriteLine("              -----------------------------")
                Console.WriteLine("              Double Cheese Burger        2")
                Console.WriteLine("              Large Fries                 2")
                Console.WriteLine("              Large Soda Can              1")
                
                end if
            
            Console.writeline("Press <ENTER> to continue")
            Console.readline
            
            dim burger as integer
            dim fries as integer  
            dim drink as integer 

            
            if mealselect = 3 Then
                burger=2
                fries =2 
                drink = 1
                
            elseif mealSelect = 2 Then
                    burger = 1
                    fries=2
                    drink= 1
                    
            elseif mealSelect = 3 Then
               burger =2
                fries =2 
                drink = 1
                
            End If
            
            Console.writeline("Action                 Price                InputKey")
            Console.WriteLine("----------------------------------------------------")
            Console.WriteLine("Extra Burger           3.00                        1")
            Console.WriteLine("Extra Fries            2.00                        2")
            Console.WriteLine("Extra Drink            1.00                        3")
            dim extraAction as String
            dim extraActionInvalid as boolean = false
            
            
            
            
            do 
                extraAction = console.ReadLine()
            if extraAction = "1" Then
                burger = burger + 1
                total = total + 3
                
                elseif extraAction = "2" then
                    fries = fries + 1
                    total = total + 2
                    
                    else if extraAction = "3" Then
                        drink = drink + 1
                        total = total + 1
                        
                        else 
                            extraActionInvalid = true
                            Console.WriteLine("invalid input,try again")
                        
                        
            End If
            loop until extraActionInvalid = false
            
            Console.WriteLine("This is your customized meal")
            Console.WriteLine("              Item                  Quantity")
            Console.WriteLine("              ------------------------------")
            Console.WriteLine("              Burgers                     " & burger)
            Console.WriteLine("              Fries                       " & fries)
            Console.WriteLine("              Soda Cans                   " & drink)
            
            Console.WriteLine("your new total is " & total)
            Console.WriteLine()
            Console.WriteLine("Press <ENTER> to continue")
            Console.ReadLine()

            
            
            
            
            
            Console.Clear()
            Exit Sub
            
            elseif mealCustomizeDec = "2" Then
                Exit Sub
            else 
                mealCustomizeDecInput = true
                Console.WriteLine("Invalid input,please try again")
        End If
        loop until mealCustomizeDecInput = false
        
        

        
    End Sub



    Sub Main()



        Do
            Console.WriteLine("Option          InputKey")
            Console.WriteLine("------------------------")
            Console.WriteLine("View Past Orders       1")
            Console.WriteLine("Make New Order         2")
            programEnter = Console.ReadLine()
            If programEnter = "1" Then

                Console.Clear()
                orderView()
            ElseIf programEnter = "2" Then
                programEnterInput = False
            Else
                Console.WriteLine("invalid input,try again")
                programEnterInput = True
            End If
        Loop Until programEnterInput = False


        Do
            ' add one to the loop counter
            loopCount = loopCount + 1
            ' set the total to 0
            total = 0
            ' decaler vInput as true
            vInput = True
            Console.Clear()
            Console.WriteLine("Welcome to the Burger Shop,Please choose a menu to view")
            Do


                Console.WriteLine("Menu                         InputKey")
                Console.WriteLine("--------------------------------------")
                Console.WriteLine("Burger                               1")
                Console.WriteLine("Sides                                2")
                Console.WriteLine("Meals                                3")
                
                Console.Clear()
                
                
                
                Do
                    mselect = Console.ReadLine()
                    
                    If mselect = "1" Then
                        Console.WriteLine("Item                 Price        InputKey")
                        Console.WriteLine("---------------------------------------------------------------------------")
                        Console.WriteLine("Cheese Burger         1.99               1")
                        Console.WriteLine("- A delicous 1/4 oz beef patty with a piece of chedder cheese melted on top")
                        Console.WriteLine("---------------------------------------------------------------------------")
                        Console.WriteLine("Hamburger             2.99               2")
                        Console.WriteLine("- A succulent beef patty cooked to perfection")
                        Console.WriteLine("---------------------------------------------------------------------------")
                        Console.WriteLine("Chicken Burger        2.50               3")
                        Console.WriteLine("- A crispy chicken patty topped with house sauce")
                        Do
                            bselect = Console.ReadLine()

                            If bselect = "1" Then
                                total = total + 1.99
                                Console.WriteLine("You have selected Cheese Burger,your total is now $" & total)

                            ElseIf bselect = "2" Then
                                total = total + 2.99
                                Console.WriteLine("You have selected Hamburger,your total is now $" & total)

                            ElseIf bselect = "3" Then
                                total = total + 2.5
                                Console.WriteLine("You have selected Chicken Burger,your total is now $" & total)

                            Else
                                Console.WriteLine("Invalid input while selecting burger,please try again")
                            End If

                        Loop Until bselect = "1" Or "2" Or "3"

                    ElseIf mselect = "2" Then
                        ' sides menu
                        Console.WriteLine("Item                 Price        InputKey")
                        Console.WriteLine("------------------------------------------")
                        Console.WriteLine("French Fries         1.99                1")
                        Console.WriteLine("Cheese Sticks        2.99                2")
                        Console.WriteLine("Apple Pie            2.50                3")

                        Do
                            sSelect = Console.ReadLine()
                            If sSelect = 1 Then
                                total = total + 1.99
                                Console.WriteLine("You have ordered French Fries and your total is $" & total)
                            ElseIf sSelect = 2 Then
                                total = total + 2.99
                                Console.WriteLine("You have ordered Cheese sticks and your total is $" & total)
                            ElseIf sSelect = 3 Then
                                total = total + 2.5
                                Console.WriteLine("You have ordered Apple Pie and your total is $" & total)
                            Else
                                Console.WriteLine("Invalid input while selecting side,please try again")
                            End If
                        Loop Until sSelect = 1 Or 2 Or 3

                    ElseIf mselect = "3" Then
                        ' meals menu
                        Console.WriteLine("Item                 Price        InputKey")
                        Console.WriteLine("------------------------------------------")
                        Console.WriteLine("Basic Meal           4.99                1")
                        Console.WriteLine("Premium Meal         5.99                2")
                        Console.WriteLine("Luxury Meal          8.99                3")

                        Do
                            mealSelect = Console.ReadLine()
                            If mealSelect = 1 Then
                                total = total + 4.99
                                Console.WriteLine("You have selected the Basic Meal and your total is $" & total)
                            ElseIf mealSelect = 2 Then
                                total = total + 5.99
                                Console.WriteLine("You have selected the Premium Meal and your total is $" & total)
                            ElseIf mealSelect = 3 Then
                                total = total + 8.99
                                Console.WriteLine("You have selected the Luxury Meal and your total is $" & total)
                            Else
                                Console.WriteLine("Invalid input while selecting meal, please try again")
                            End If
                        Loop Until mealSelect = 1 Or 2 Or 3

                    Else
                        Console.WriteLine("Invalid Input while selecting menu,Please try again")
                        vInput = False
                    End If

                Loop Until vInput = True
                Console.Clear()

                If mselect = "3" Then
                    mealCustomizer(total)
                End If



                Console.Clear()

                orderCustomeizerInvalid = False

                Do
                    Console.WriteLine("              Extras Menu            ")
                    Console.WriteLine("-------------------------------------")
                    Console.WriteLine("-------------------------------------")
                    Console.WriteLine("Item             Price       InputKey")
                    Console.WriteLine("BBQ Sauce        $0.50              1")
                    Console.WriteLine("Mayo Sauce       $0.50              2")
                    Console.WriteLine("Ketchup Sauce    $0.50              3")
                    Console.WriteLine("Chilli Sauce     $0.50              4")
                    If mselect = "1" Then
                        Console.WriteLine("Cheese Slice     $0.40              5")
                        Console.WriteLine("Extra Lettuce    $0.10              6")
                        Console.WriteLine("Extra Onion      $0.20              7")
                        Console.WriteLine("Pickles          $0.20              8")
                    End If

                    orderCustomizer = Console.ReadLine()

                    If orderCustomizer > 8 Then
                        orderCustomeizerInvalid = True


                    End If

                    If orderCustomeizerInvalid = True Then
                        Console.WriteLine("invalid input,please try agian")
                    End If

                Loop Until orderCustomeizerInvalid = False

                If orderCustomizer < 5 Then
                    total = total + 0.5

                ElseIf orderCustomizer = 5 Then
                    total = total + 0.4

                ElseIf orderCustomizer = 6 Then
                    total = total + 0.1

                ElseIf orderCustomizer = 7 Or 8 Then

                    total = total + 0.2
                End If


                Console.WriteLine("ThenYour total is $" & total)
                    Console.WriteLine("Would you like to see the menu and add to your order?")


                    Do
                        Console.WriteLine("Option       InputKey")
                        Console.WriteLine("---------------------")
                        Console.WriteLine("Yes                 1")
                        Console.WriteLine("No                  2")
                        loopSelect = Console.ReadLine()


                        If loopSelect = 1 Then
                            pLoop = True

                        ElseIf loopSelect = 2 Then
                            pLoop = False

                        Else
                            Console.WriteLine("Invalid input , please try again")
                        End If

                        Console.Clear()

                    Loop Until loopSelect = 1 Or 2



                Loop Until pLoop = False

                orderinfo(loopCount, 0) = FormatNumber(total * 1.02, 2)


            Console.WriteLine("Thank you for placing your order.")

            Console.WriteLine("What is the first name for delivery?")

            Do
                name = Console.ReadLine()

                If Len(name) > 10 Then
                    Console.WriteLine("Invalid Input, Please try again")
                End If


            Loop Until Len(name) < 10

            Console.WriteLine("What is the second name for delivery?")

            Do
                sname = Console.ReadLine()

                If Len(sname) > 10 Or sname = "" Then
                    Console.WriteLine("Invalid Input, Please try again")
                End If


            Loop Until Len(sname) < 10 And sname <> ""

            orderinfo(loopCount, 3) = Len(name) & Mid(sname, 1, 4)

            name = UCase(Mid(name, 1, 1)) + Mid(name, 2, Len(orderinfo(loopCount, 1) - 1))
            sname = UCase(Mid(sname, 1, 1)) + Mid(sname, 2, Len(sname) - 1)

            orderinfo(loopCount, 1) = name '
            orderinfo(loopCount, 2) = sname
            Console.Clear()

            studentDiscuont()

            Dim invalidTipDec As Boolean = False


            Console.WriteLine("Would you like to top 5% to help starving kids in Africa(Y/N)")

            Do
                tipChoice = UCase(Console.ReadLine())


                If tipChoice = "Y" Then
                    invalidTipDec = False
                    orderinfo(programLoop, 0) = orderinfo(loopCount, 0) * 1.05
                    Console.WriteLine("Thank you, your total is now $" & orderinfo(loopCount, 0))

                ElseIf tipChoice = "N" Then
                    invalidTipDec = False
                    Console.WriteLine("Cruel Being. Your total will remain the same at $" & orderinfo(loopCount, 0))

                Else
                    Console.WriteLine("invalid input,try again")
                    invalidTipDec = True
                End If


            Loop Until invalidTipDec = False

            'orderinfo(0) is the total
            'orderinfo(1) is first name
            'orderinfo(2) is second name
            'orderinfo(3) is identifier
            'orderline(4) is full name
            orderinfo(loopCount, 0) = "$" + orderinfo(loopCount, 0)

            Console.Clear()

            Console.WriteLine("                   _       _   
                  (_)     | |  
 _ __ ___  ___ ___ _ _ __ | |_ 
| '__/ _ \/ __/ _ \ | '_ \| __|
| | |  __/ (_|  __/ | |_) | |_ 
|_|  \___|\___\___|_| .__/ \__|
                    | |        
                    |_|        ")

            Console.WriteLine("                                   First Name        |      Last Name       |       Total       |     OrderID |")
            Console.WriteLine("                              -----------------------|----------------------|-------------------|-------------|")
            Console.WriteLine("                                      " & orderinfo(loopCount, 1) & "              " & orderinfo(loopCount, 2) & "                " & orderinfo(loopCount, 0) & "            " & orderinfo(loopCount, 3) & "   ")


















            ' ///////////////////////////////////////////////////////////////////////////

            Console.WriteLine("Would you like the program to loop?")
            pLoopinput = Console.ReadLine()
            If UCase(pLoopinput) = "YES" And loopCount < 3 Then
                programLoop = True
                Console.Clear()
            ElseIf loopCount >= 3 Then
                Console.WriteLine("Can't loop more than 3 times")
                programLoop = False
            Else
                programLoop = False
            End If




        Loop Until programLoop = False

        Dim sw As New StreamWriter("orders.txt", True)

        Console.WriteLine("                                        First Name   |      Last Name       |       Total       |     OrderID |")



        For i = 1 To loopCount

            Console.WriteLine("                              -----------------------|----------------------|-------------------|-------------|")
            sw.WriteLine("                                  -----------------------|----------------------|-------------------|-------------|")
            Console.WriteLine("                                      " & orderinfo(i, 1) & "              " & orderinfo(i, 2) & "                " & orderinfo(i, 0) & "            " & orderinfo(i, 3) & "   ")
            sw.WriteLine("                                      " & orderinfo(i, 1) & "                   " & orderinfo(i, 2) & "                " & orderinfo(i, 0) & "            " & orderinfo(i, 3) & "   ")

        Next
        sw.Close()

        Console.ReadLine()
    End Sub

End Module
