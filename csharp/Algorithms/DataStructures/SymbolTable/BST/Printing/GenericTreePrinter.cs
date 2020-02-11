using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace RiskAndPricingSolutions.Algorithms.DataStructures.SymbolTable.BST.Printing
{
    /// <summary>
    /// Translated from Java code listed here
    /// https://github.com/billvanyo/tree_printer/
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericTreePrinter<T>
    {
        private Func<T, String> getLabel;
        private Func<T, T> getLeft;
        private Func<T, T> getRight;

        private TextWriter outStream = Console.Out;

        private bool squareBranches = false;
        private bool lrAgnostic = false;
        private int hspace = 2;
        private int tspace = 1;

        public GenericTreePrinter(Func<T, String> getLabel, Func<T, T> getLeft, Func<T, T> getRight)
        {
            this.getLabel = getLabel;
            this.getLeft = getLeft;
            this.getRight = getRight;
        }

        public void setPrintStream(TextWriter outStream)
        {
            this.outStream = outStream;
        }

        public void setSquareBranches(bool squareBranches)
        {
            this.squareBranches = squareBranches;
        }

        public void setLrAgnostic(bool lrAgnostic)
        {
            this.lrAgnostic = lrAgnostic;
        }

        public void setHspace(int hspace)
        {
            this.hspace = hspace;
        }

        public void setTspace(int tspace)
        {
            this.hspace = tspace;
        }

        /*
            Prints ascii representation of binary searchTree.
            Parameter hspace is minimum number of spaces between adjacent node labels.
            Parameter squareBranches, when set to true, results in branches being printed with ASCII box
            drawing characters.
         */
        public void printTree(T root)
        {
            List<TreeLine> treeLines = buildTreeLines(root);
            printTreeLines(treeLines);
        }

        /*
            Prints ascii representations of multiple trees across page.
            Parameter hspace is minimum number of spaces between adjacent node labels in a searchTree.
            Parameter tspace is horizontal distance between trees, as well as number of blank lines
            between rows of trees.
            Parameter lineWidth is maximum width of output
            Parameter squareBranches, when set to true, results in branches being printed with ASCII box
            drawing characters.
         */
        public void printTrees(List<T> trees, int lineWidth)
        {
            List<List<TreeLine>> allTreeLines = new List<List<TreeLine>>();
            int[] treeWidths = new int[trees.Count];
            int[] minLeftOffsets = new int[trees.Count];
            int[] maxRightOffsets = new int[trees.Count];
            for (int i = 0; i < trees.Count; i++)
            {
                T treeNode = trees[i];
                List<TreeLine> treeLines = buildTreeLines(treeNode);
                allTreeLines.Add(treeLines);
                minLeftOffsets[i] = MinLeftOffset(treeLines);
                maxRightOffsets[i] = MaxRightOffset(treeLines);
                treeWidths[i] = maxRightOffsets[i] - minLeftOffsets[i] + 1;
            }

            int nextTreeIndex = 0;
            while (nextTreeIndex < trees.Count)
            {
                // print a row of trees starting at nextTreeIndex

                // first figure range of trees we can print for next row
                int sumOfWidths = treeWidths[nextTreeIndex];
                int endTreeIndex = nextTreeIndex + 1;
                while (endTreeIndex < trees.Count && sumOfWidths + tspace + treeWidths[endTreeIndex] < lineWidth)
                {
                    sumOfWidths += (tspace + treeWidths[endTreeIndex]);
                    endTreeIndex++;
                }

                endTreeIndex--;

                // find max number of lines for tallest searchTree
                int maxLines = allTreeLines.Select(list => list.Count).Max();

                // print trees line by line
                for (int i = 0; i < maxLines; i++)
                {
                    for (int j = nextTreeIndex; j <= endTreeIndex; j++)
                    {
                        List<TreeLine> treeLines = allTreeLines[j];
                        if (i >= treeLines.Count)
                        {
                            Console.Write(spaces(treeWidths[j]));
                        }
                        else
                        {
                            int leftSpaces = -(minLeftOffsets[j] - treeLines[i].leftOffset);
                            int rightSpaces = maxRightOffsets[j] - treeLines[i].rightOffset;
                            Console.Write(spaces(leftSpaces) + treeLines[i].line + spaces(rightSpaces));
                        }

                        if (j < endTreeIndex) Console.Out.Write(spaces(tspace));
                    }

                    Console.WriteLine();
                }

                for (int i = 0; i < tspace; i++)
                {
                    Console.WriteLine();
                }

                nextTreeIndex = endTreeIndex + 1;
            }
        }

        private void printTreeLines(List<TreeLine> treeLines)
        {
            if (treeLines.Count > 0)
            {
                int minLeftOffset = MinLeftOffset(treeLines);
                int maxRightOffset = MaxRightOffset(treeLines);
                foreach (TreeLine treeLine in treeLines)
                {
                    int leftSpaces = -(minLeftOffset - treeLine.leftOffset);
                    int rightSpaces = maxRightOffset - treeLine.rightOffset;
                    outStream.WriteLine(spaces(leftSpaces) + treeLine.line + spaces(rightSpaces));
                }
            }
        }

        private List<TreeLine> buildTreeLines(T root)
        {
            if (root == null) return new List<TreeLine>();
            else
            {
                String rootLabel = getLabel(root);
                List<TreeLine> leftTreeLines = buildTreeLines(getLeft(root));
                List<TreeLine> rightTreeLines = buildTreeLines(getRight(root));

                int leftCount = leftTreeLines.Count;
                int rightCount = rightTreeLines.Count;
                int minCount = Math.Min(leftCount, rightCount);
                int maxCount = Math.Max(leftCount, rightCount);

                // The left and right subtree print representations have jagged edges, and we essentially we have to
                // figure out how close together we can bring the left and right roots so that the edges just meet on
                // some line.  Then we add hspace, and round up to next odd number.
                int maxRootSpacing = 0;
                for (int i = 0; i < minCount; i++)
                {
                    int spacing = leftTreeLines[i].rightOffset - rightTreeLines[i].leftOffset;
                    if (spacing > maxRootSpacing) maxRootSpacing = spacing;
                }

                int rootSpacing = maxRootSpacing + hspace;
                if (rootSpacing % 2 == 0) rootSpacing++;
                // rootSpacing is now the number of spaces between the roots of the two subtrees

                List<TreeLine> allTreeLines = new List<TreeLine>();

                // add the root and the two branches leading to the subtrees

                allTreeLines.Add(new TreeLine(rootLabel, -(rootLabel.Length - 1) / 2, rootLabel.Length / 2));

                // also calculate offset adjustments for left and right subtrees
                int leftTreeAdjust = 0;
                int rightTreeAdjust = 0;

                if (leftTreeLines.Count == 0)
                {
                    if (rightTreeLines.Count != 0)
                    {
                        // there's a right subtree only
                        if (squareBranches)
                        {
                            if (lrAgnostic)
                            {
                                allTreeLines.Add(new TreeLine("\u2502", 0, 0));
                            }
                            else
                            {
                                allTreeLines.Add(new TreeLine("\u2514\u2510", 0, 1));
                                rightTreeAdjust = 1;
                            }
                        }
                        else
                        {
                            allTreeLines.Add(new TreeLine("\\", 1, 1));
                            rightTreeAdjust = 2;
                        }
                    }
                }
                else if (rightTreeLines.Count == 0)
                {
                    // there's a left subtree only
                    if (squareBranches)
                    {
                        if (lrAgnostic)
                        {
                            allTreeLines.Add(new TreeLine("\u2502", 0, 0));
                        }
                        else
                        {
                            allTreeLines.Add(new TreeLine("\u250C\u2518", -1, 0));
                            leftTreeAdjust = -1;
                        }
                    }
                    else
                    {
                        allTreeLines.Add(new TreeLine("/", -1, -1));
                        leftTreeAdjust = -2;
                    }
                }
                else
                {
                    // there's a left and right subtree
                    if (squareBranches)
                    {
                        int adjust = (rootSpacing / 2) + 1;
                        String horizontal = String.Join("", Enumerable.Repeat("\u2500", rootSpacing / 2));
                        String branch = "\u250C" + horizontal + "\u2534" + horizontal + "\u2510";
                        allTreeLines.Add(new TreeLine(branch, -adjust, adjust));
                        rightTreeAdjust = adjust;
                        leftTreeAdjust = -adjust;
                    }
                    else
                    {
                        if (rootSpacing == 1)
                        {
                            allTreeLines.Add(new TreeLine("/ \\", -1, 1));
                            rightTreeAdjust = 2;
                            leftTreeAdjust = -2;
                        }
                        else
                        {
                            for (int i = 1; i < rootSpacing; i += 2)
                            {
                                String branches = "/" + spaces(i) + "\\";
                                allTreeLines.Add(new TreeLine(branches, -((i + 1) / 2), (i + 1) / 2));
                            }

                            rightTreeAdjust = (rootSpacing / 2) + 1;
                            leftTreeAdjust = -((rootSpacing / 2) + 1);
                        }
                    }
                }

                // now add joined lines of subtrees, with appropriate number of separating spaces, and adjusting offsets

                for (int i = 0; i < maxCount; i++)
                {
                    TreeLine leftLine, rightLine;
                    if (i >= leftTreeLines.Count)
                    {
                        // nothing remaining on left subtree
                        rightLine = rightTreeLines[i];
                        rightLine.leftOffset += rightTreeAdjust;
                        rightLine.rightOffset += rightTreeAdjust;
                        allTreeLines.Add(rightLine);
                    }
                    else if (i >= rightTreeLines.Count)
                    {
                        // nothing remaining on right subtree
                        leftLine = leftTreeLines[i];
                        leftLine.leftOffset += leftTreeAdjust;
                        leftLine.rightOffset += leftTreeAdjust;
                        allTreeLines.Add(leftLine);
                    }
                    else
                    {
                        leftLine = leftTreeLines[i];
                        rightLine = rightTreeLines[i];
                        int adjustedRootSpacing = (rootSpacing == 1 ? (squareBranches ? 1 : 3) : rootSpacing);
                        TreeLine combined = new TreeLine(
                            leftLine.line + spaces(adjustedRootSpacing - leftLine.rightOffset + rightLine.leftOffset) +
                            rightLine.line,
                            leftLine.leftOffset + leftTreeAdjust, rightLine.rightOffset + rightTreeAdjust);
                        allTreeLines.Add(combined);
                    }
                }

                return allTreeLines;
            }
        }

        private int MinLeftOffset(List<TreeLine> treeLines)
        {
            return treeLines.Select(l => l.leftOffset).Min();
        }

        private int MaxRightOffset(List<TreeLine> treeLines)
        {
            return treeLines.Select(l => l.rightOffset).Max();
        }

        private static String spaces(int n)
        {
            return String.Join("", Enumerable.Repeat(" ", n));
        }

        public class TreeLine
        {
            public String line;
            public int leftOffset;
            public int rightOffset;

            public TreeLine(String line, int leftOffset, int rightOffset)
            {
                this.line = line;
                this.leftOffset = leftOffset;
                this.rightOffset = rightOffset;
            }
        }
    }
}
