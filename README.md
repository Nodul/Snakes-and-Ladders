# (Sub)tasks

* As a player I want to see the game board, so that I can see what is the status of the current game.
	- [X] Create Board data structure
	- [X] Create Board Tile data structure
	- [X] Display the board
	- [X] Make the board tiles properly align
	- [X] Add colors to board tiles
	- [X] Center camera on board

* As a player I want to move my token based on the roll of a die So that there is an element of chance in the game
	- [X] Create Dice structure
	- [X] Roll dice on click
	- [X] Display dice roll result

* As a player I want to be able to move my token So that I can get closer to the goal
	- [X] Add Token
	- [X] Make Token move on Dice roll

* As a player I want to be able to win the game So that I can gloat to everyone around
	- [X] make player bounce from final tile if he rolls a too high number
	- [X] Stop game and display Win message when player reaches final tile

* As a player, I want to be able to have other players play as well So that the game is more fun
	- [X] Add support for up to 4 players
		- [X] place all tokens properly
		- [X] add different colors to tokens
		- [X] players take turns rolling dice and moving their token

* As a player I want snakes to move my token down So that the game is more fun
	- [X] Add Snake structure
	- [ ] Display snake properly
	- [ ] Make tokens go down the snake if they step on it's head
	- [ ] Randomly assign a few snakes at start

* As a player I want ladders to move my token up So that the game is more fun
	- [ ] Add Ladder structure
	- [ ] Display Ladder properly
	- [ ] Make tokens go up the ladder if the step on it's bottom
	- [ ] Randomly assign a few Ladder at start

* As a player I want a main menu, where I can setup game settings, like number of players and their names, so that I can have more fun
	- [ ] Main menu scene
	- [ ] New game button
	- [ ] List of players + names text boxes
	- [ ] Make main game scene initialize with data from Main Menu scene

# The Task

Snakes and Ladders is a board game involving two or more players rolling dice in order to move their tokens across a board. The board is made up of a collection of numbered squares and is adorned with 'snakes' and 'ladders', which link two squares on the board- snakes link the squares downwards whilst ladders link them going upwards. This means that landing at the bottom of a ladder moves you to the top of that ladder, whereas landing on the top of a snake moves you to the bottom of that snake. The objective of the game is to get your token to the final square before your opponents do.

# Requirements

For this technical assignment, you are requested to build a small application to implement the snakes and ladder board game. We ask you to create your own repository to host your solution.

Below are some user stories that can help you designing the solution.

* As a player I want to be able to move my token So that I can get closer to the goal
* As a player I want to move my token based on the roll of a die So that there is an element of chance in the game
* As a player I want to be able to win the game So that I can gloat to everyone around
* As a player I want snakes to move my token down So that the game is more fun
* As a player I want ladders to move my token up So that the game is more fun

# Insights

The goal of this test is to objectively evaluate your technical skills, here are some insights into what we will be looking for when reviewing your solution.

* Feel free to commit as often as you'd like. The more commits the better! Please commit at least once within the first hour
* It's better to complete 1 task than to start 3
* Feel free to use any libraries you feel appropriate
* We will be looking at how you approach the task (e.g. how you break it into sub-tasks) and how you structure your code

# Credits

* Palette - Endesga 32 Palette - created by Endesga - https://lospec.com/palette-list/endesga-32
* Dice sprites - created by JamesWhite - https://opengameart.org/content/dice-4
* Snake sprites - created by actuallypav - https://opengameart.org/content/snake-tilemap