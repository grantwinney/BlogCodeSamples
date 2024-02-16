import subprocess
import sys
import bottlenose

amazon = bottlenose.Amazon("your-access-key", "your-secret-key", "your-store-id")

response = amazon.ItemSearch(Keywords="Raspberry Pi", SearchIndex="Electronics")

# response = amazon.ItemLookup(ItemId="B07BQFX4SB")

print(response)
