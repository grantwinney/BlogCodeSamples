import random
from tkinter import *     # use Tkinter for Python2
window = Tk()
window.title("Welcome to LikeGeeks app")
window.geometry('800x480')

mid_h = 320
mid_v = 240

results = {
    'Back-end Dev': 55.2,
    'Full-stack Dev': 54.9,
    'Front-end Dev': 37.1,
    'Desktop / Enterprise': 23.9,
    'Mobile Dev': 19.2,
    'DevOps': 12.1,
    'DB Admin': 11.6,
    'Designer': 10.8,
    'System Admin': 10.6,
    'Embedded Apps': 9.6,
    'Data / Business Analyst': 8.2,
    'Data Scientist / Machine Learning': 8.1,
    'QA / Tester': 8,
    'Data Engineer': 7.6,
    'Academic Researcher': 7.2,
    'Educator': 5.9,
    'Gaming / Graphics': 5.6,
    'Engineering Manager': 5.5,
    'Product Manager': 5.1,
    'Scientist': 4.2
}

def rnd_pos():
    return 1 if random.random() < 0.5 else -1

for dev_type, percentage in results.items():
    start_pos = int(165-(percentage*3))
    color = '#%02x%02x%02x' % (50+start_pos, 50+start_pos, 255)
    lbl = Label(window, text=dev_type, font=("Arial", int(percentage)), fg=color)
    lbl.place(x=mid_h-(start_pos*rnd_pos()), y=mid_v-(start_pos*rnd_pos()))

window.mainloop()
