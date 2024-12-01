package main

import (
	"bufio"
	"fmt"
	"math"
	"os"
	"sort"
	"strconv"
	"strings"
)

func main() {
	fmt.Println("Day One")
	inputFile, err := os.Open("Data/DayOne")

	if err != nil {
		fmt.Fprintf(os.Stderr, "Failed to open input data: %v\n", err)
		os.Exit(-1)
	}

	partOne(inputFile)
	partTwo(inputFile) // 23082277
}

func partOne(inputFile *os.File) {
	inputFile.Seek(0, 0)
	reader := bufio.NewScanner(inputFile)
	leftIds := make([]int, 4096)
	rightIds := make([]int, 4096)

	for reader.Scan() {
		ids := strings.Split(reader.Text(), "   ")

		leftId, _ := strconv.Atoi(ids[0])
		rightId, _ := strconv.Atoi(ids[1])

		leftIds = append(leftIds, leftId)
		rightIds = append(rightIds, rightId)
	}

	sort.Slice(leftIds, func(i, j int) bool {
		return leftIds[i] < leftIds[j]
	})

	sort.Slice(rightIds, func(i, j int) bool {
		return rightIds[i] < rightIds[j]
	})

	solution := 0

	for i := 0; i < len(leftIds); i++ {
		diff := int(math.Abs(float64(leftIds[i]) - float64(rightIds[i])))
		solution += diff
	}

	fmt.Printf("\tPart One: %d\n", solution)
}

func partTwo(inputFile *os.File) {
	inputFile.Seek(0, 0)
	reader := bufio.NewScanner(inputFile)
	leftIds := make([]int, 4096)
	rightIds := make([]int, 4096)

	for reader.Scan() {
		ids := strings.Split(reader.Text(), "   ")

		leftId, _ := strconv.Atoi(ids[0])
		rightId, _ := strconv.Atoi(ids[1])

		leftIds = append(leftIds, leftId)
		rightIds = append(rightIds, rightId)
	}

	solution := 0

	for _, leftId := range leftIds {
		occurrences := 0

		for _, rightId := range rightIds {
			if leftId == rightId {
				occurrences++
			}
		}

		solution += leftId * occurrences
	}

	fmt.Printf("\tPart One: %d\n", solution)
}
