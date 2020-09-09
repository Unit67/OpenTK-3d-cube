#include <GLFW/glfw3.h>
#include <glm/vec3.hpp>
#include <glm\ext\matrix_float4x4.hpp>
#include <GL/glut.h>
#include <Cube.h>

int main()
{
    GLFWwindow* window;
    
    /* Initialize the library */
    if (!glfwInit())
        return -1;

    /* Create a windowed mode window and its OpenGL context */
    window = glfwCreateWindow(640, 480, "Hello World", NULL, NULL);
    if (!window)
    {
        glfwTerminate();
        return -1;
    }

    /* Make the window's context current */
    glfwMakeContextCurrent(window);

    float CamX = 0.1f, CamY = 0.1f, CamZ = 0.1f;
    float CamRX = 0.1f, CamRY = 0.1f, CamRZ = 0.1f;


    /* Loop until the user closes the window */
    while (!glfwWindowShouldClose(window))
    {

        glMatrixMode(GL_PROJECTION);
        glLoadIdentity();                  // Reset the model-view matrix
        gluPerspective(60, 1, 1.0, 50);

        int stateA = glfwGetKey(window, GLFW_KEY_A);
        int stateD = glfwGetKey(window, GLFW_KEY_D);
        int stateW = glfwGetKey(window, GLFW_KEY_W);
        int stateS = glfwGetKey(window, GLFW_KEY_S);
        int stateLShift = glfwGetKey(window, GLFW_KEY_LEFT_SHIFT);
        int stateSpace = glfwGetKey(window, GLFW_KEY_SPACE);
        
        int stateK= glfwGetKey(window, GLFW_KEY_K);
        int stateH = glfwGetKey(window, GLFW_KEY_H);

        int angle = 0.0f;

        if (stateK == GLFW_PRESS)
        {
            CamRX = CamRX - 1.5f;
        }
        if (stateH == GLFW_PRESS)
        {
            CamRX = CamRX + 1.5f;
        }
        
        if (stateA == GLFW_PRESS)
        {
            CamX = CamX + 1.1f;
        }
        if (stateD == GLFW_PRESS)
        {
            CamX = CamX - 1.1f;
        }
        if (stateLShift == GLFW_PRESS)
        {
            CamY = CamY + 1.1f;
        }
        if (stateSpace == GLFW_PRESS)
        {
            CamY = CamY - 1.1f;
        }
        if (stateW == GLFW_PRESS)
        {
            CamZ = CamZ + 1.1f;
        }
        if (stateS == GLFW_PRESS)
        {
            CamZ = CamZ - 1.1f;
        }
        
        glTranslatef(CamX,CamY,CamZ);  // Move
        angle = angle + 1.0f;

        gluLookAt(CamRX, CamRY, CamRZ, CamX, CamY, CamZ, 0, 1, 0);
        //glRotatef(angle, 0, 0, 1);
        /* Render here */
        glClear(GL_COLOR_BUFFER_BIT);
        
        glBegin(GL_QUADS);                // Begin drawing the color cube with 6 quads
        // Top face (y = 1.0f)
        // Define vertices in counter-clockwise (CCW) order with normal pointing out
        glColor3f(1.0f, 1.0f, 1.0f);    
        glVertex3f(5.0f, 1.0f, -5.0f);
        glVertex3f(-5.0f, 1.0f, -5.0f);
        glVertex3f(-5.0f, 1.0f, 5.0f);
        glVertex3f(5.0f, 1.0f, 5.0f);

        // Bottom face (y = -1.0f)
        glColor3f(1.0f, 1.0f, 1.0f); 
        glVertex3f(5.0f, -1.0f, 5.0f);
        glVertex3f(-5.0f, -1.0f, 5.0f);
        glVertex3f(-5.0f, -1.0f, -5.0f);
        glVertex3f(5.0f, -1.0f, -5.0f);

        // Front face  (z = 1.0f)
        glColor3f(1.0f, 1.0f, 1.0f);   
        glVertex3f(5.0f, 1.0f, 5.0f);
        glVertex3f(-5.0f, 1.0f, 5.0f);
        glVertex3f(-5.0f, -1.0f, 5.0f);
        glVertex3f(5.0f, -1.0f, 5.0f);

        // Back face (z = -1.0f)
        glColor3f(1.0f, 1.0f, 1.0f);     
        glVertex3f(5.0f, -1.0f, -5.0f);
        glVertex3f(-5.0f, -1.0f, -5.0f);
        glVertex3f(-5.0f, 1.0f, -5.0f);
        glVertex3f(5.0f, 1.0f, -5.0f);

        // Left face (x = -1.0f)
        glColor3f(1.0f, 1.0f, 1.0f);     
        glVertex3f(-5.0f, 1.0f, 5.0f);
        glVertex3f(-5.0f, 1.0f, -5.0f);
        glVertex3f(-5.0f, -1.0f, -5.0f);
        glVertex3f(-5.0f, -1.0f, 5.0f);

        // Right face (x = 1.0f)
        glColor3f(1.0f, 1.0f, 1.0f);    
        glVertex3f(5.0f, 1.0f, -5.0f);
        glVertex3f(5.0f, 1.0f, 5.0f);
        glVertex3f(5.0f, -1.0f, 5.0f);
        glVertex3f(5.0f, -1.0f, -5.0f);
        glEnd();  // End of drawing color-cube

        /* Swap front and back buffers */
        glfwSwapBuffers(window);

        /* Poll for and process events */
        glfwPollEvents();
    }

    glfwTerminate();
    return 0;
}