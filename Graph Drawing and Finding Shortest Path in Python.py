import networkx as nx
import matplotlib.pyplot as plt

g=nx.DiGraph()
labels = {}
g.add_node(0)
g.add_node(1)
g.add_node(2)
g.add_node(3)
g.add_node(4)
for node in g.nodes():
    labels[node] = node
g.nodes[0]['pos'] = (0,2)
g.nodes[1]['pos'] = (3,0)
g.nodes[2]['pos'] = (2,-3)
g.nodes[3]['pos'] = (-2,-3)
g.nodes[4]['pos'] = (-3,0)


node_pos=nx.get_node_attributes(g,'pos')

g.add_edge(0,1,weight=5.0)
g.add_edge(0,4,weight=2.0)
g.add_edge(0,2,weight=3.0)

g.add_edge(1,2,weight=2.0)
g.add_edge(1,3,weight=6.0)

g.add_edge(2,1,weight=1.0)
g.add_edge(2,3,weight=2.0)

g.add_edge(4,1,weight=6.0)
g.add_edge(4,2,weight=10.0)
g.add_edge(4,3,weight=4.0)

arc_weight=nx.get_edge_attributes(g,'weight')
#nx.draw_networkx(g, node_pos,node_color= 'red', node_size=450)
nx.draw_networkx_edges(g,node_pos,edgelist=[(0,1),(0,4),(0,2),(1,3),(2,3),(4,1),(4,2),(4,3)])
nx.draw_networkx_edges(g, node_pos,connectionstyle='arc3, rad = 0.1', edgelist= [(2,1)])
nx.draw_networkx_edges(g, node_pos,connectionstyle='arc3, rad = 0.1', edgelist= [(1,2)])
nx.draw_networkx_edge_labels(g, node_pos,font_color= 'black', edge_labels=arc_weight)
nx.draw_networkx_nodes(g,node_pos,node_color= 'red', node_size=450,label=node_pos)
nx.draw_networkx_labels(g,node_pos,labels,font_size=13,font_color='black')

plt.show()
for i in range(4):
    try:
        print("4 den ",i,"'e giden en kısa yol: ",nx.dijkstra_path(g,4,i))
    except:
        print("4 den",i,"e giden yol yok")

g.remove_node(3)
labels = {}
for node in g.nodes():
    labels[node] = node
arc_weight=nx.get_edge_attributes(g,'weight')
nx.draw_networkx_edges(g,node_pos,edgelist=[(0,1),(0,4),(0,2),(4,1),(4,2)])
nx.draw_networkx_edges(g, node_pos,connectionstyle='arc3, rad = 0.1', edgelist= [(2,1)])
nx.draw_networkx_edges(g, node_pos,connectionstyle='arc3, rad = 0.1', edgelist= [(1,2)])
nx.draw_networkx_edge_labels(g, node_pos,font_color= 'black', edge_labels=arc_weight)
nx.draw_networkx_nodes(g,node_pos,node_color= 'red', node_size=450,label=node_pos)
nx.draw_networkx_labels(g,node_pos,labels,font_size=13,font_color='black')
plt.show()
for i in range(4):
    try:
        print("4 den ",i,"'e giden en kısa yol: ",nx.dijkstra_path(g,4,i))
    except:
        print("4 den",i,"e giden yol yok")

input()