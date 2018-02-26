using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace TreeViewDragDrop
{
    public static class TreeViewExtension
    {
        public static List<TreeNode> Descendants(this TreeView tree)
        {
            var nodes = tree.Nodes.Cast<TreeNode>();
            return nodes.SelectMany(x => x.Descendants()).Concat(nodes).ToList();
        }

        public static List<TreeNode> Descendants(this TreeNode node)
        {
            var nodes = node.Nodes.Cast<TreeNode>().ToList();
            return nodes.SelectMany(x => Descendants(x)).Concat(nodes).ToList();
        }

        public static void AddNodeToTree(this TreeView tree, TreeNode node)
        {
            if (node != null)
            {
                if (!checkNodeExists(tree, node))
                {
                    AddParent(tree, node.Parent);
                    AddNode(tree, node);
                }
                AddChildNodes(tree, node.Nodes);
                node.Expand();
            }
        }

        public static void CreateTree(this TreeView tree, string folderPath)
        {
            if (Directory.Exists(folderPath))
            {
                string folderName = Path.GetFileName(folderPath);
                TreeNode foldernode = new TreeNode
                {
                    Text = folderName,
                    Tag = createNodeInfo(folderPath, folderName, false)
                };
                tree.Nodes.Add(foldernode);
                string[] folderPaths = getFolders(folderPath);
                foreach (string path in folderPaths)
                {
                    AddFolder(foldernode, path);
                }
                AddFiles(foldernode, folderPath);
            }
        }

        public static List<KeyValuePair<string, string>> GetAllFilesWithPath(this TreeView tree)
        {
            return tree.Descendants()
                .Where(n => ((NodeInfo)n.Tag).IsFile)
                .Select(x =>  new KeyValuePair<string, string>(((NodeInfo)x.Tag).Name, ((NodeInfo)x.Tag).Path))
                .ToList();
        }

        private static void AddFolder(TreeNode parentfoldernode, string folderpath)
        {
            if (Directory.Exists(folderpath))
            {                
                string folderName = Path.GetFileName(folderpath);
                TreeNode foldernode = new TreeNode
                {
                    Text = folderName,
                    Tag = createNodeInfo(folderpath, folderName, false)
                };                
                parentfoldernode.Nodes.Add(foldernode);
                string[] folderPaths = getFolders(folderpath);
                foreach (string path in folderPaths)
                {                    
                    AddFolder(foldernode, path);                    
                }
                AddFiles(foldernode, folderpath);
            }
        }

        private static void AddFiles(TreeNode folderNode, string folderpath)
        {
            if (Directory.Exists(folderpath))
            {
                string[] filePaths = getFiles(folderpath);
                foreach (string path in filePaths)
                {
                    string fileName = Path.GetFileName(path);
                    TreeNode node = new TreeNode
                    {
                        Text = fileName,
                        Tag = createNodeInfo(path, fileName, true)
                    };                    
                    folderNode.Nodes.Add(node);
                }
            }
        }

        private static NodeInfo createNodeInfo(string path, string name, bool isFile)
        {
            return new NodeInfo
            {
                Path = path,
                Name = name,
                IsFile = isFile
            };
        }

        private static string[] getFolders(string path)
        {
            return Directory.GetDirectories(path)
                .Where(d => !new DirectoryInfo(d).Attributes.HasFlag(FileAttributes.System | FileAttributes.Hidden))
                .ToArray();
        }

        private static string[] getFiles(string path)
        {
            return Directory.GetFiles(path)
                .Where(d => !new FileInfo(d).Attributes.HasFlag(FileAttributes.System | FileAttributes.Hidden))
                .ToArray();
        }

        private static void AddChildNodes(TreeView tree, TreeNodeCollection nodes)
        {
            if (nodes != null && nodes.Count > 0)
            {
                foreach (TreeNode node in nodes)
                {
                    if (!checkNodeExists(tree, node))
                    {
                        AddNode(tree, node);
                    }
                    AddChildNodes(tree, node.Nodes);
                }
            }
        }

        private static void AddParent(TreeView tree, TreeNode node)
        {
            if (node != null)
            {
                if (!checkNodeExists(tree, node))
                {
                    AddParent(tree, node.Parent);
                    AddNode(tree, node);
                }
            }
        }

        private static TreeNode cloneNode(TreeNode node)
        {
            return new TreeNode
            {
                Text = node.Text,
                Tag = node.Tag
            };
        }

        private static void AddNode(TreeView tree, TreeNode node)
        {
            TreeNode clonedNode = cloneNode(node);
            if (node.Parent == null)
            {
                tree.Nodes.Add(clonedNode);
            }
            else
            {
                TreeNode parentNode = getNode(tree, (NodeInfo)node.Parent.Tag);
                parentNode.Nodes.Add(clonedNode);
            }
        }

        private static TreeNode getNode(TreeView tree, NodeInfo tag)
        {
            return tree
                .Descendants()
                .Where(n => string.Equals(((NodeInfo)n.Tag).Path, tag.Path))
                .FirstOrDefault();
        }

        private static bool checkNodeExists(TreeView tree, TreeNode sourcenode)
        {
            return tree
                .Descendants()
                .Where(n => string.Equals(((NodeInfo)n.Tag).Path, ((NodeInfo)sourcenode.Tag).Path))
                .FirstOrDefault() != null;
        }
    }
}
