#include "CMT.h"
#include "gui.h"

#include <opencv2/highgui/highgui.hpp>
#include <opencv2/imgproc/imgproc.hpp>

using namespace cmt;
using namespace cv;

static string WIN_NAME = "CMT";

int main(int argc, char **argv)
{
    CMT *cmt = new CMT();
    Rect *rect;

	cmt->str_descriptor = "BRISK";
	cmt->str_detector = "BRISK";
	cmt->consensus.estimate_scale = false;
    cmt->consensus.estimate_rotation = true;

    //Create window
    namedWindow(WIN_NAME);

	VideoCapture cap;

    bool show_preview = true;

	cap.open(0); //Open default camera device

    //Get initial image
    Mat im0;
    cap >> im0;

    rect = getRect(im0, WIN_NAME);

    //Convert im0 to grayscale
    Mat im0_gray;
    cvtColor(im0, im0_gray, CV_BGR2GRAY);

    //Initialize CMT
    cmt->initialize(im0_gray, rect);

    //Main loop
    while (true)
    {
        Mat im;

        //If loop flag is set, reuse initial image (for debugging purposes)
        cap >> im; //Else use next image in stream

        if (im.empty()) break; //Exit at end of video stream

        Mat im_gray;
        cvtColor(im, im_gray, CV_BGR2GRAY);

        //Let CMT process the frame
        cmt->processFrame(im_gray);

		cv::rectangle(im, cmt->bb_rot.boundingRect(), Scalar(255, 0, 0), 2);
		Point2f vertices[4];
		cmt->bb_rot.points(vertices);
		for (int i = 0; i < 4; i++)
			line(im, vertices[i], vertices[(i+1)%4], Scalar(255,0,0));

		imshow(WIN_NAME, im);

		cv::waitKey(20);
    }

    return 0;
}
