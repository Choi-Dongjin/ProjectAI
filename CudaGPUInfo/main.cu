#include "cuda_runtime.h"
#include "device_launch_parameters.h"

#include <stdio.h>

extern "C" __declspec(dllexport) int getCudaGpuInfo() {
	int deviceCount = 0;
	cudaGetDeviceCount(&deviceCount);

	if (deviceCount == 0)
	{
		printf("No CUDA support device found");
	}

	int devNo = 0;
	cudaDeviceProp iProp;
	cudaGetDeviceProperties(&iProp, devNo);

	printf("   Device %d: %s\n",
		devNo, iProp.name);
	printf("   Number of multiprocessors:           %d\n",
		iProp.multiProcessorCount);
	printf("   clock rate : % d\n",
		iProp.clockRate);
	printf("   Compute capability    :      %d.%d\n",
		iProp.major, iProp.minor);
	printf("   Total amount of global memory :       %4.2f KB\n",
		iProp.totalGlobalMem / 1024.0);
	printf("   Total amount of constant memory:      %4.2f KB\n",
		iProp.totalConstMem / 1024.0);
	printf("   Total amount of shared memory per block:      %4.2f KB\n",
		iProp.sharedMemPerBlock / 1024.0);
	printf("   Total amount of max Threads per block:      %d\n",
		iProp.maxThreadsPerBlock);
	printf("   Total amount of max Grids per x, y, z:      %d %d %d\n",
		iProp.maxGridSize[0], iProp.maxGridSize[1], iProp.maxGridSize[2]);
	printf("   Total amount of max Threads per Dim x, Dim y, DIm z:      %d %d %d\n",
		iProp.maxThreadsDim[0], iProp.maxThreadsDim[1], iProp.maxThreadsDim[2]);
	printf("   Warp size : %d",
		iProp.warpSize);

	int gpuMemory = static_cast<int>(iProp.totalGlobalMem / 1024.0);
	return gpuMemory;
}

int main()
{
	getCudaGpuInfo();
	printf("\nEnd Cuda\n");
}