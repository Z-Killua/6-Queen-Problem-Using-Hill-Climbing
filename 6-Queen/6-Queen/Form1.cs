using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _6_Queen
{
    public partial class Form1 : Form
    {
        int side, n = 6;
        SixState startState, currentState;
        int[,] hTable;
        ArrayList bMoves;
        Object chosenMove;

        public Form1()
        {
            InitializeComponent();

            side = board.Width / n;

            startState = randomSixState();
            currentState = new SixState(startState);

            updateUI();
            board.Refresh(); //Refresh UI positions
            attackingPairs.Text = "Attacking pairs: " + getAttackingPairs(startState);
        }

        private void board_Click(object sender, EventArgs e){}

        private void reset_Click(object sender, EventArgs e)
        {
            startState = randomSixState();
            currentState = new SixState(startState);

            updateUI();
            board.Refresh();
            attackingPairs.Text = "Attacking pairs: " + getAttackingPairs(startState);
        }

        private SixState randomSixState()
        {
            Random r = new Random();
            SixState random = new SixState(r.Next(n),
            r.Next(n),
            r.Next(n),
            r.Next(n),
            r.Next(n),
            r.Next(n));

            return random;
        }

        private void updateUI()
        {
            board.Refresh();
            attackingPairs.Text = "Attacking Pairs: " + getAttackingPairs(currentState);
            hTable = getHeuristicTableForPossibleMoves(currentState);
            bMoves = getBestMoves(hTable);

            if (bMoves.Count > 0)
                chosenMove = chooseMove(bMoves);
        }

        private ArrayList getBestMoves(int[,] heuristicTable)
        {
            ArrayList bestMoves = new ArrayList();
            int bestHeuristicValue = heuristicTable[0, 0];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (bestHeuristicValue > heuristicTable[i, j])
                    {
                        bestHeuristicValue = heuristicTable[i, j];
                        bestMoves.Clear();

                        if (currentState.Y[i] != j)
                            bestMoves.Add(new Point(i, j));
                    }
                    else if (bestHeuristicValue == heuristicTable[i, j])
                    {
                        if (currentState.Y[i] != j)
                            bestMoves.Add(new Point(i, j));
                    }
                }
            }
           
            return bestMoves;
        }

        private Object chooseMove(ArrayList possibleMoves)
        {
            int arrayLength = possibleMoves.Count;
            Random r = new Random();
            int randomMove = r.Next(arrayLength);// code here next move to choose form the possible moves

            return possibleMoves[randomMove];
        }

        private int[,] getHeuristicTableForPossibleMoves(SixState current)
        {
            int[,] hStates = new int[n, n];

            for (int i = 0; i < n; i++) // go through the indices
            {
                for (int j = 0; j < n; j++) // replace them with a new value
                {

                    // put code here
                    SixState better = new SixState(current);
                    better.Y[i] = j;
                    hStates[i, j] = getAttackingPairs(better);

                }
            }

            return hStates;
        }

        private void Move_Click(object sender, EventArgs e)
        {
            if (getAttackingPairs(currentState) > 0)
                executeMove((Point)chosenMove);
        }

        private void executeMove(Point move)
        {
            for (int i = 0; i < n; i++)
                startState.Y[i] = currentState.Y[i];
            
            currentState.Y[move.X] = move.Y;

            chosenMove = null;
            updateUI();
        }

        private void attackingPairs_Click(object sender, EventArgs e) { }

        private void Form1_Load(object sender, EventArgs e){}

        private int getAttackingPairs(SixState f)
        {
            int attackers = 0;
            for (int rf = 0; rf < n; rf++)
            {
                for (int tar = rf + 1; tar < n; tar++)
                {

                    // get horizontal attackers
                    if (f.Y[rf] == f.Y[tar])
                        attackers++;

                }
                for (int tar = rf + 1; tar < n; tar++)
                {

                    // get diagonal down attackers
                    if (f.Y[tar] == f.Y[rf] + tar - rf)
                        attackers++;

                }
                for (int tar = rf + 1; tar < n; tar++)
                {

                    // get diagonal up attackers
                    if (f.Y[rf] == f.Y[tar] + tar - rf)
                        attackers++;

                }
            }
            return attackers;
        }

        private void Solve_Click(object sender, EventArgs e)
        {
            while (getAttackingPairs(currentState) > 0)
                executeMove((Point)chosenMove);
        }

        private void board_Paint(object sender, PaintEventArgs e)
        {
            // draw squares
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if ((i + j) % 2 == 0)
                        e.Graphics.FillRectangle(Brushes.Black, i * side, j * side, side, side);

                    // draw queens
                    if (j == currentState.Y[i])
                        e.Graphics.FillEllipse(Brushes.Teal, i * side, j * side, side, side);
                }
            }
        }
    }
}
